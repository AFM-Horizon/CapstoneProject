using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.DataAccess.Subject
{
    /// <summary>
    /// The <see cref="ISubjectRepository"/> allows us to work against an abstraction when we want to retrieve subject data.
    /// This allows for decoupling so that when we finally get access to a real A.P.I we wont have to change any controller code.  
    /// </summary>
    public interface ISubjectRepository : IRepository<Subject, string>
    {
        //ISubjectRepository implements IRepository,  This essentially amounts to a promise
        //to have all the methods from IRepository implemented and publicly available  
    }
}
