using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProject.DataAccess.Subject;

namespace CapstoneProject.DataAccess.UnitOfWork
{
    /// <summary>
    /// The <see cref="UnitOfWork"/> allows us to gather up our various repositories and other injected services as we go forward to make
    /// constructor injection neater and more streamlined in our controllers.  
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ISubjectRepository subjectRepository)
        {
            SubjectRepository = subjectRepository;
        }

        public ISubjectRepository SubjectRepository { get; private set; }
    }
}
