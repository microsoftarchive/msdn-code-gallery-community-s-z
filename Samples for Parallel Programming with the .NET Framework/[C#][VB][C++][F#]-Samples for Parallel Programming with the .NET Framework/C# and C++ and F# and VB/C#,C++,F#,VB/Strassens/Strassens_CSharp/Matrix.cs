//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Matrix.cs
//
//--------------------------------------------------------------------------

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

public sealed unsafe class Matrix : IDisposable
{
    private int _size;
    private static int[] _validSizes = new[] { 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536 };
    private int[] _data;
    private int* _dataPtr;
    private GCHandle _dataPtrHandle;

    public Matrix(int size)
    {
        if (!_validSizes.Contains(size)) throw new ArgumentOutOfRangeException("size");
        _size = size;
        _data = new int[size * size];

        _dataPtrHandle = GCHandle.Alloc(_data, GCHandleType.Pinned);
        _dataPtr = (int*)_dataPtrHandle.AddrOfPinnedObject().ToPointer();
    }

    ~Matrix() { Dispose(); }
    public void Dispose()
    {
        if (_data != null)
        {
            _dataPtrHandle.Free();
            _data = null;
        }
    }

    public int[] ValidSizes { get { return _validSizes.ToArray(); } }

    public void FillWithRandomValues()
    {
        Random rand = new Random();
        for (int i = 0; i < _data.Length; i++)
        {
            _data[i] = rand.Next() % 127;
        }
    }

    public bool Equals(Matrix other)
    {
        if (_size != other._size) return false;
        for (int i = 0; i < _data.Length; i++) if (_data[i] != other._data[i]) return false;
        return true;
    }

    public static void Multiply(CancellationToken cancellationToken, Matrix src1, Matrix src2, Matrix dst)
    {
        if (src1._size != src2._size || src1._size != dst._size) throw new ArgumentOutOfRangeException("src1");
        int N = src1._size;
        matrix_mult_serial(
            cancellationToken,
            N, N, N,
            src1._dataPtr, 0, 0, N,
            src2._dataPtr, 0, 0, N,
            dst._dataPtr, 0, 0, N);
    }

    public static void MultiplyParallel(CancellationToken cancellationToken, Matrix src1, Matrix src2, Matrix dst)
    {
        if (src1._size != src2._size || src1._size != dst._size) throw new ArgumentOutOfRangeException("src1");
        int N = src1._size;
        matrix_mult_parallel(
            cancellationToken,
            N, N, N,
            src1._dataPtr, 0, 0, N,
            src2._dataPtr, 0, 0, N,
            dst._dataPtr, 0, 0, N);
    }

    public static void MultiplyStrassens(CancellationToken cancellationToken, Matrix src1, Matrix src2, Matrix dst)
    {
        if (src1._size != src2._size || src1._size != dst._size) throw new ArgumentOutOfRangeException("src1");
        int N = src1._size;
        strassen_mult_serial(
            cancellationToken,
            N,
            src1._dataPtr, 0, 0, N,
            src2._dataPtr, 0, 0, N,
            dst._dataPtr, 0, 0, N,
            64);
    }

    public static void MultiplyStrassensParallel(CancellationToken cancellationToken, Matrix src1, Matrix src2, Matrix dst)
    {
        if (src1._size != src2._size || src1._size != dst._size) throw new ArgumentOutOfRangeException("src1");
        int N = src1._size;
        strassen_mult_parallel(
            cancellationToken,
            N,
            src1._dataPtr, 0, 0, N,
            src2._dataPtr, 0, 0, N,
            dst._dataPtr, 0, 0, N,
            64);
    }

    private static void matrix_add( 
        // dimensions of A, B, and C submatrices 
        int n, int m,
        // (ax,ay) = origin of A submatrix for multiplicand 
        int* A, int ax, int ay, int a_s,
        // (bx,by) = origin of B submatrix for multiplicand 
        int* B, int bx, int by, int bs,
        // (cx,cy) = origin of C submatrix for result 
        int* C, int cx, int cy, int cs)
    {
        for (int i = 0; i < n; i += 1)
            for (int j = 0; j < m; j += 1)
                C[(i + cx) * cs + j + cy] = A[(i + ax) * a_s + j + ay] + B[(i + bx) * bs + j + by];
    }

    private static void matrix_sub(
        // dimensions of A, B, and C submatrices 
        int n, int m,
        // (ax,ay) = origin of A submatrix for multiplicand 
        int* A, int ax, int ay, int a_s,
        // (bx,by) = origin of B submatrix for multiplicand 
        int* B, int bx, int by, int bs,
        // (cx,cy) = origin of C submatrix for result 
        int* C, int cx, int cy, int cs)
    {
        for (int i = 0; i < n; i += 1)
        {
            for (int j = 0; j < m; j += 1)
            {
                C[(i + cx) * cs + j + cy] = A[(i + ax) * a_s + j + ay] - B[(i + bx) * bs + j + by];
            }
        }
    }

    private static void matrix_mult_serial(
        CancellationToken cancellationToken, 
        // dimensions of A (lxm), B(mxn), and C(lxn) submatrices 
        int l, int m, int n,
        // (ax,ay) = origin of A submatrix for multiplicand 
        int* A, int ax, int ay, int a_s,
        // (bx,by) = origin of B submatrix for multiplicand 
        int* B, int bx, int by, int bs,
        // (cx,cy) = origin of C submatrix for result 
        int* C, int cx, int cy, int cs)
    {
        for (int i = 0; i < l; ++i)
        {
            cancellationToken.ThrowIfCancellationRequested();
            for (int j = 0; j < n; j++)
            {
                int temp = 0;
                for (int k = 0; k < m; k++)
                {
                    temp += A[(i + ax) * a_s + k + ay] * B[(k + bx) * bs + j + by];
                }
                C[(i + cx) * cs + j + cy] = temp;
            }
        }
    }

    private static void matrix_mult_parallel(
        CancellationToken cancellationToken, 
        // dimensions of A (lxm), B(mxn), and C(lxn) submatrices 
        int l, int m, int n,
        // (ax,ay) = origin of A submatrix for multiplicand 
        int* A, int ax, int ay, int a_s,
        // (bx,by) = origin of B submatrix for multiplicand 
        int* B, int bx, int by, int bs,
        // (cx,cy) = origin of C submatrix for result 
        int* C, int cx, int cy, int cs)
    {
        ParallelOptions options = new ParallelOptions { CancellationToken = cancellationToken };
        Parallel.For(0, l, options, i =>
        {
            for (int j = 0; j < n; j++)
            {
                int temp = 0;
                for (int k = 0; k < m; k++)
                {
                    temp += A[(i + ax) * a_s + k + ay] * B[(k + bx) * bs + j + by];
                }
                C[(i + cx) * cs + j + cy] = temp;
            }
        });
    }

    private static void strassen_mult_serial(
        CancellationToken cancellationToken, 
        // dimensions of A, B, and C submatrices 
        int n,
        // (ax,ay) = origin of A submatrix for multiplicand 
        int* A, int ax, int ay, int a_s,
        // (bx,by) = origin of B submatrix for multiplicand 
        int* B, int bx, int by, int bs,
        // (cx,cy) = origin of C submatrix for result 
        int* C, int cx, int cy, int cs,
        // Strassen's recursion limit for array dimensions 
        int s)
    {
        if (n <= s)
        {
            matrix_mult_serial(
                cancellationToken,
                n, n, n,
                A, ax, ay, a_s,
                B, bx, by, bs,
                C, cx, cy, cs);
        }
        else
        {
            int n_2 = n >> 1;
            int[] workArr = new int[n_2 * n_2 * 9];
            fixed (int* work = workArr)
            {
                int* a_cum = work;
                int* b_cum = a_cum + n_2 * n_2;
                int* p1 = b_cum + n_2 * n_2;
                int* p2 = p1 + n_2 * n_2;
                int* p3 = p2 + n_2 * n_2;
                int* p4 = p3 + n_2 * n_2;
                int* p5 = p4 + n_2 * n_2;
                int* p6 = p5 + n_2 * n_2;
                int* p7 = p6 + n_2 * n_2;

                // p1 = (a11 + a22) * (b11 + b22) 
                matrix_add(n_2, n_2,
                    A, ax, ay, a_s,
                    A, ax + n_2, ay + n_2, a_s,
                    a_cum, 0, 0, n_2);
                matrix_add(n_2, n_2,
                    B, bx, by, bs,
                    B, bx + n_2, by + n_2, bs,
                    b_cum, 0, 0, n_2);
                strassen_mult_serial(
                    cancellationToken,
                    n_2,
                    a_cum, 0, 0, n_2,
                    b_cum, 0, 0, n_2,
                    p1, 0, 0, n_2,
                    s);

                // p2 = (a21 + a22) * b11 
                matrix_add(n_2, n_2,
                    A, ax + n_2, ay, a_s,
                    A, ax + n_2, ay + n_2, a_s,
                    a_cum, 0, 0, n_2);
                strassen_mult_serial(
                    cancellationToken,
                    n_2,
                    a_cum, 0, 0, n_2,
                    B, bx, by, bs,
                    p2, 0, 0, n_2,
                    s);

                // p3 = a11 x (b12 - b22) 
                matrix_sub(n_2, n_2,
                    B, bx, by + n_2, bs,
                    B, bx + n_2, by + n_2, bs,
                    b_cum, 0, 0, n_2);
                strassen_mult_serial(
                    cancellationToken,
                    n_2,
                    A, ax, ay, a_s,
                    b_cum, 0, 0, n_2,
                    p3, 0, 0, n_2,
                    s);

                // p4 = a22 x (b21 - b11) 
                matrix_sub(n_2, n_2,
                    B, bx + n_2, by, bs,
                    B, bx, by, bs,
                    b_cum, 0, 0, n_2);
                strassen_mult_serial(
                    cancellationToken,
                    n_2,
                    A, ax + n_2, ay + n_2, a_s,
                    b_cum, 0, 0, n_2,
                    p4, 0, 0, n_2,
                    s);

                // p5 = (a11 + a12) x b22 
                matrix_add(n_2, n_2,
                    A, ax, ay, a_s,
                    A, ax, ay + n_2, a_s,
                    a_cum, 0, 0, n_2);
                strassen_mult_serial(
                    cancellationToken,
                    n_2,
                    a_cum, 0, 0, n_2,
                    B, bx + n_2, by + n_2, bs,
                    p5, 0, 0, n_2,
                    s);

                // p6 = (a21 - a11) x (b11 + b12) 
                matrix_sub(n_2, n_2,
                    A, ax + n_2, ay, a_s,
                    A, ax, ay, a_s,
                    a_cum, 0, 0, n_2);
                matrix_add(n_2, n_2,
                    B, bx, by, bs,
                    B, bx, by + n_2, bs,
                    b_cum, 0, 0, n_2);
                strassen_mult_serial(
                    cancellationToken,
                    n_2,
                    a_cum, 0, 0, n_2,
                    b_cum, 0, 0, n_2,
                    p6, 0, 0, n_2,
                    s);

                // p7 = (a12 - a22) x (b21 + b22) 
                matrix_sub(n_2, n_2,
                    A, ax, ay + n_2, a_s,
                    A, ax + n_2, ay + n_2, a_s,
                    a_cum, 0, 0, n_2);
                matrix_add(n_2, n_2,
                    B, bx + n_2, by, bs,
                    B, bx + n_2, by + n_2, bs,
                    b_cum, 0, 0, n_2);
                strassen_mult_serial(
                    cancellationToken,
                    n_2,
                    a_cum, 0, 0, n_2,
                    b_cum, 0, 0, n_2,
                    p7, 0, 0, n_2,
                    s);

                // c11 = p1 + p4 - p5 + p7 
                matrix_add(n_2, n_2,
                    p1, 0, 0, n_2,
                    p4, 0, 0, n_2,
                    C, cx, cy, cs);
                matrix_sub(n_2, n_2,
                    C, cx, cy, cs,
                    p5, 0, 0, n_2,
                    C, cx, cy, cs);
                matrix_add(n_2, n_2,
                    C, cx, cy, cs,
                    p7, 0, 0, n_2,
                    C, cx, cy, cs);

                // c12 = p3 + p5 
                matrix_add(n_2, n_2,
                    p3, 0, 0, n_2,
                    p5, 0, 0, n_2,
                    C, cx, cy + n_2, cs);

                // c21 = p2 + p4 
                matrix_add(n_2, n_2,
                    p2, 0, 0, n_2,
                    p4, 0, 0, n_2,
                    C, cx + n_2, cy, cs);

                // c22 = p1 + p3 - p2 + p6 
                matrix_add(n_2, n_2,
                    p1, 0, 0, n_2,
                    p3, 0, 0, n_2,
                    C, cx + n_2, cy + n_2, cs);
                matrix_sub(n_2, n_2,
                    C, cx + n_2, cy + n_2, cs,
                    p2, 0, 0, n_2,
                    C, cx + n_2, cy + n_2, cs);
                matrix_add(n_2, n_2,
                    C, cx + n_2, cy + n_2, cs,
                    p6, 0, 0, n_2,
                    C, cx + n_2, cy + n_2, cs);
            }
        }
    }

    private static void strassen_mult_parallel(
        CancellationToken cancellationToken, 
        // dimensions of A, B, and C submatrices 
        int n,
        // (ax,ay) = origin of A submatrix for multiplicand 
        int* A, int ax, int ay, int a_s,
        // (bx,by) = origin of B submatrix for multiplicand 
        int* B, int bx, int by, int bs,
        // (cx,cy) = origin of C submatrix for result 
        int* C, int cx, int cy, int cs,
        // Strassen's recursion limit for array dimensions 
        int s)
    {
        if (n <= s)
        {
            matrix_mult_serial(
                cancellationToken,
                n, n, n,
                A, ax, ay, a_s,
                B, bx, by, bs,
                C, cx, cy, cs);
        }
        else
        {
            int n_2 = n >> 1;
            int areaSize = n_2 * n_2;
            int[] workArr = new int[areaSize * 17];
            fixed (int* work = workArr)
            {
                int* a_cum = work;
                int* b_cum = a_cum + areaSize;
                int* c_cum = b_cum + areaSize;
                int* d_cum = c_cum + areaSize;
                int* e_cum = d_cum + areaSize;
                int* f_cum = e_cum + areaSize;
                int* g_cum = f_cum + areaSize;
                int* h_cum = g_cum + areaSize;
                int* i_cum = h_cum + areaSize;
                int* j_cum = i_cum + areaSize;
                int* p1 = j_cum + areaSize;
                int* p2 = p1 + areaSize;
                int* p3 = p2 + areaSize;
                int* p4 = p3 + areaSize;
                int* p5 = p4 + areaSize;
                int* p6 = p5 + areaSize;
                int* p7 = p6 + areaSize;

                // p1 = (a11 + a22) * (b11 + b22) 
                Task t_p1 = Task.Factory.StartNew(() =>
                {
                    matrix_add(n_2, n_2,
                        A, ax, ay, a_s,
                        A, ax + n_2, ay + n_2, a_s,
                        a_cum, 0, 0, n_2);
                    matrix_add(n_2, n_2,
                        B, bx, by, bs,
                        B, bx + n_2, by + n_2, bs,
                        b_cum, 0, 0, n_2);
                    strassen_mult_parallel(
                        cancellationToken,
                        n_2,
                        a_cum, 0, 0, n_2,
                        b_cum, 0, 0, n_2,
                        p1, 0, 0, n_2,
                        s);
                }, cancellationToken);

                // p2 = (a21 + a22) * b11 
                Task t_p2 = Task.Factory.StartNew(() =>
                {
                    matrix_add(n_2, n_2,
                        A, ax + n_2, ay, a_s,
                        A, ax + n_2, ay + n_2, a_s,
                        c_cum, 0, 0, n_2);
                    strassen_mult_parallel(
                        cancellationToken,
                        n_2,
                        c_cum, 0, 0, n_2,
                        B, bx, by, bs,
                        p2, 0, 0, n_2,
                        s);
                }, cancellationToken);

                // p3 = a11 x (b12 - b22) 
                Task t_p3 = Task.Factory.StartNew(() =>
                {
                    matrix_sub(n_2, n_2,
                        B, bx, by + n_2, bs,
                        B, bx + n_2, by + n_2, bs,
                        d_cum, 0, 0, n_2);
                    strassen_mult_parallel(
                        cancellationToken,
                        n_2,
                        A, ax, ay, a_s,
                        d_cum, 0, 0, n_2,
                        p3, 0, 0, n_2,
                        s);
                }, cancellationToken);

                // p4 = a22 x (b21 - b11) 
                Task t_p4 = Task.Factory.StartNew(() =>
                {
                    matrix_sub(n_2, n_2,
                        B, bx + n_2, by, bs,
                        B, bx, by, bs,
                        e_cum, 0, 0, n_2);
                    strassen_mult_parallel(
                        cancellationToken,
                        n_2,
                        A, ax + n_2, ay + n_2, a_s,
                        e_cum, 0, 0, n_2,
                        p4, 0, 0, n_2,
                        s);
                }, cancellationToken);

                // p5 = (a11 + a12) x b22 
                Task t_p5 = Task.Factory.StartNew(() =>
                {
                    matrix_add(n_2, n_2,
                        A, ax, ay, a_s,
                        A, ax, ay + n_2, a_s,
                        f_cum, 0, 0, n_2);
                    strassen_mult_parallel(
                        cancellationToken,
                        n_2,
                        f_cum, 0, 0, n_2,
                        B, bx + n_2, by + n_2, bs,
                        p5, 0, 0, n_2,
                        s);
                }, cancellationToken);

                // p6 = (a21 - a11) x (b11 + b12) 
                Task t_p6 = Task.Factory.StartNew(() =>
                {
                    matrix_sub(n_2, n_2,
                        A, ax + n_2, ay, a_s,
                        A, ax, ay, a_s,
                        g_cum, 0, 0, n_2);
                    matrix_add(n_2, n_2,
                        B, bx, by, bs,
                        B, bx, by + n_2, bs,
                        h_cum, 0, 0, n_2);
                    strassen_mult_parallel(
                        cancellationToken,
                        n_2,
                        g_cum, 0, 0, n_2,
                        h_cum, 0, 0, n_2,
                        p6, 0, 0, n_2,
                        s);
                }, cancellationToken);

                // p7 = (a12 - a22) x (b21 + b22) 
                Task t_p7 = Task.Factory.StartNew(() =>
                {
                    matrix_sub(n_2, n_2,
                        A, ax, ay + n_2, a_s,
                        A, ax + n_2, ay + n_2, a_s,
                        i_cum, 0, 0, n_2);
                    matrix_add(n_2, n_2,
                        B, bx + n_2, by, bs,
                        B, bx + n_2, by + n_2, bs,
                        j_cum, 0, 0, n_2);
                    strassen_mult_parallel(
                        cancellationToken,
                        n_2,
                        i_cum, 0, 0, n_2,
                        j_cum, 0, 0, n_2,
                        p7, 0, 0, n_2,
                        s);
                }, cancellationToken);

                try { Task.WaitAll(t_p1, t_p2, t_p3, t_p4, t_p5, t_p6, t_p7); }
                catch (AggregateException ae)
                {
                    ae.Flatten().Handle(e => e is TaskCanceledException);
                    cancellationToken.ThrowIfCancellationRequested();
                }

                // c11 = p1 + p4 - p5 + p7 
                Task t_c11 = Task.Factory.StartNew(() =>
                {
                    matrix_add(n_2, n_2,
                        p1, 0, 0, n_2,
                        p4, 0, 0, n_2,
                        C, cx, cy, cs);
                    matrix_sub(n_2, n_2,
                        C, cx, cy, cs,
                        p5, 0, 0, n_2,
                        C, cx, cy, cs);
                    matrix_add(n_2, n_2,
                        C, cx, cy, cs,
                        p7, 0, 0, n_2,
                        C, cx, cy, cs);
                });

                // c12 = p3 + p5 
                Task t_c12 = Task.Factory.StartNew(() =>
                {
                    matrix_add(n_2, n_2,
                        p3, 0, 0, n_2,
                        p5, 0, 0, n_2,
                        C, cx, cy + n_2, cs);
                });

                // c21 = p2 + p4 
                Task t_c21 = Task.Factory.StartNew(() =>
                {
                    matrix_add(n_2, n_2,
                        p2, 0, 0, n_2,
                        p4, 0, 0, n_2,
                        C, cx + n_2, cy, cs);
                });

                // c22 = p1 + p3 - p2 + p6 
                Task t_c22 = Task.Factory.StartNew(() =>
                {
                    matrix_add(n_2, n_2,
                        p1, 0, 0, n_2,
                        p3, 0, 0, n_2,
                        C, cx + n_2, cy + n_2, cs);
                    matrix_sub(n_2, n_2,
                        C, cx + n_2, cy + n_2, cs,
                        p2, 0, 0, n_2,
                        C, cx + n_2, cy + n_2, cs);
                    matrix_add(n_2, n_2,
                        C, cx + n_2, cy + n_2, cs,
                        p6, 0, 0, n_2,
                        C, cx + n_2, cy + n_2, cs);
                });

                Task.WaitAll(t_c11, t_c12, t_c21, t_c22);
            }
        }
    }
}