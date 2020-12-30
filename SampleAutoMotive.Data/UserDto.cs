using SampleAutoMotive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAutoMotive.Data
{
    public class UserDto
    {

        public List<UserModel> GetUsers()
        {
            using (var autoContext = new SampleAutoMotiveEntities())
            {
                var users = autoContext.Users
                    .Select(x => new UserModel
                    {
                        Id = x.ID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        Gender = x.Gender

                    }).ToList();

                return users;
            }
        }

        public UserModel GetSingleUser(long id)
        {
            using (var autoContext = new SampleAutoMotiveEntities())
            {
                var users = autoContext.Users.Where(x => x.ID == id)
                    .Select(x => new UserModel
                    {
                        Id = x.ID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        Gender = x.Gender

                    }).FirstOrDefault();

                return users;
            }
        }

        public bool AddUser(UserModel userModel)
        {
            try
            {
                using (var autoContext = new SampleAutoMotiveEntities())
                {
                    User ouser = new User();
                    ouser.FirstName = userModel.FirstName;
                    ouser.LastName = userModel.LastName;
                    ouser.Age = userModel.Age;
                    ouser.Gender = userModel.Gender;

                    autoContext.Users.Add(ouser);
                    autoContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public bool Update(UserModel userModel)
        {
            try
            {
                using (var autoContext = new SampleAutoMotiveEntities())
                {

                    User ouser = autoContext.Users.Where(u => u.ID == userModel.Id).FirstOrDefault();

                    if (ouser != null)
                    {
                        ouser.FirstName = userModel.FirstName;
                        ouser.LastName = userModel.LastName;
                        ouser.Age = userModel.Age;
                        ouser.Gender = userModel.Gender;
                        autoContext.SaveChanges();
                    }                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(long userId)
        {
            try
            {
                using (var autoContext = new SampleAutoMotiveEntities())
                {
                    User ouser = autoContext.Users.Where(u => u.ID == userId).FirstOrDefault();

                    if (ouser != null)
                    {
                        autoContext.Users.Remove(ouser);
                        autoContext.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
