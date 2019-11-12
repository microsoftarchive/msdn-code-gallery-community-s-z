import { Inject, Injectable } from '@angular/core';
import { Http, Response} from '@angular/http';
import { Product } from './product';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ProductsService {
    public products: Product[];

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    getProducts(): Observable<Product[]> {
        return this.http.get(this.baseUrl + 'api/Products')
            .map((result: Response) => {
                return result.json() as Product[];
            })
            .catch(this.handleError);
    }

    private handleError(error: any) {
        console.error('server error:', error);
        if (error instanceof Response) {
            let errMessage = '';
            try {
                errMessage = error.json().error;
            } catch (err) {
                errMessage = error.statusText || '';
            }
            return Observable.throw(errMessage);
        }

        return Observable.throw(error || 'ASP.NET Core 2.0 server error.');
    }
}