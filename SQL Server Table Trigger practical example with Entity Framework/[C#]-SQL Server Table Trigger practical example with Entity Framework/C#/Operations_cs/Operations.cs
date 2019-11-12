using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Operations_cs
{
    /// <summary>
    /// Backend read and update operations and reporting
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Get all records for TestTable
        /// </summary>
        /// <returns></returns>
        public List<TestTable> Read()
        {
            using (DemoEntities entity = new DemoEntities())
            {
                return entity.TestTables.ToList();
            }
        }
        /// <summary>
        /// Get alll statuses
        /// </summary>
        /// <returns></returns>
        public List<string> StatusList()
        {
            using (DemoEntities entity = new DemoEntities())
            {
                return entity.OrderStatus.Select(status => status.Status).ToList();
            }
        }
        /// <summary>
        /// Returns a group set for OrderStatus
        /// </summary>
        /// <returns></returns>
        public string GroupedStatus()
        {
            var sbGrouped = new System.Text.StringBuilder();

            using (DemoEntities entity = new DemoEntities())
            {
                IQueryable<GroupCount> results = entity.TestTables
                    .GroupBy(item => item.OrderStatus)
                    .Select(item => new GroupCount
                        {
                            Key = item.Key,
                            Count = item.Count()
                        }
                );               

                foreach (var item in results)
                {
                    sbGrouped.AppendLine($"{item.Key} - {item.Count}");
                }

            }

            return sbGrouped.ToString();

        }
        /// <summary>
        /// Update a row in the table
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        /// <remarks>
        /// We don't need a task based method but wanted to show
        /// how since many desktop developers are not use to this
        /// who are just learning.
        /// </remarks>
        public async Task<TestTable> UpdateItem(TestTable sender)
        {
            using (DemoEntities entity = new DemoEntities())
            {
                entity.Entry(sender).State = EntityState.Modified;

                await entity.SaveChangesAsync();

                var testTableItem = await(entity.TestTables.Where(item => item.Id == sender.Id).FirstOrDefaultAsync<TestTable>());

                return testTableItem;
            }

        }
        /// <summary>
        /// Get new approval date
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public DateTime? GetApprovalDate(TestTable sender)
        {
            using (DemoEntities entity = new DemoEntities())
            {
                return entity.TestTables.Where(item => item.Id == sender.Id).FirstOrDefault().OrderApprovalDateTime;
            }
        }
    }
}
