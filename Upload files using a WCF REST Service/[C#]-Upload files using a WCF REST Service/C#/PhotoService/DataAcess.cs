/* Copyright 2012 Marco Minerva, marco.minerva@gmail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoService
{
    public class DataAcess : IDisposable
    {
        private PhotoManagerEntities data;

        public DataAcess()
        {
            data = new PhotoManagerEntities();
        }

        public IQueryable<Photo> GetPhotos()
        {
            var photos = from p in data.Photos
                         orderby p.DateTime
                         select p;

            return photos;
        }

        public void InsertPhoto(Photo photo)
        {
            data.Photos.AddObject(photo);
            data.SaveChanges();
        }

        public Photo GetLastPhoto()
        {
            var lastPhoto = (from p in data.Photos
                             orderby p.DateTime descending
                             select p).FirstOrDefault();

            return lastPhoto;
        }

        public Photo GetPhoto(int id)
        {
            var photo = (from p in data.Photos
                         where p.PhotoID == id
                         select p).FirstOrDefault();

            return photo;
        }

        public void DeletePhoto(int id)
        {
            var photo = (from p in data.Photos
                         where p.PhotoID == id
                         select p).FirstOrDefault();

            if (photo != null)
            {
                data.Photos.DeleteObject(photo);
                data.SaveChanges();
            }
        }

        public void Dispose()
        {
            data.Dispose();
        }
    }
}