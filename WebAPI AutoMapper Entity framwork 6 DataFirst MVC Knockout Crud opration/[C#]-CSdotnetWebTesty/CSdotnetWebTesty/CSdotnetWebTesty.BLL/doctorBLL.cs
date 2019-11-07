using AutoMapper;
using CSdotnetWebTesty.Data;
using CSdotnetWebTestyViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSdotnetWebTesty.BLL
{
  public  class doctorBLL
    {
        public IEnumerable<doctorVM> Get()
        {
            TestyEntities _dbContext = new TestyEntities();
            List<doctorVM> query = new List<doctorVM>();
            var test = _dbContext.doctors.ToList();
            foreach (var item in test)
            {
                var temp = Mapper.Map<doctor, doctorVM>(item);
                query.Add(temp);
            }
            return query.AsQueryable();
        }
        public bool Create(doctorVM obj)
        {
            var doctorMap = Mapper.Map<doctorVM, doctor>(obj);
            TestyEntities _db = new TestyEntities();
            _db.doctors.Add(doctorMap);
            
            if (_db.SaveChanges() == 0)
            { return true; }
            return false;
        }
        public bool Update(doctorVM obj)
        {
            var _db = new TestyEntities();
            var doctor = _db.doctors.Where(tem => tem.id == obj.id && tem.user_id == obj.user_id).FirstOrDefault();
            if (doctor != null)
            {
                doctor.address = obj.address;
                //doctor.created_date = obj.created_date;
                doctor.email = obj.email;
                doctor.phone = obj.phone;

                //_db.doctors.Add(doctor);
                if (_db.SaveChanges() == 1)
                    return true;
            }
            return false;
        }
        public bool Delete(int Id)
        {
            var _db = new TestyEntities();
            var doctor = _db.doctors.Where(tem => tem.id == Id).FirstOrDefault();
            _db.doctors.Remove(doctor);
            if (_db.SaveChanges() == 0)
                return true;
            return false;
        }
        public doctorVM GetbyId(int Id)
        {
            var _db = new TestyEntities();
            var doctorVeiw = _db.doctors.Where(doct => doct.id == Id).FirstOrDefault();
            return Mapper.Map<doctor, doctorVM>(doctorVeiw);
        }
    }
}
