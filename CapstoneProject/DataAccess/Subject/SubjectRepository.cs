using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CapstoneProject.DataAccess.Subject;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace CapstoneProject.DataAccess.Subject
{
    /// <summary>
    ///This is the concrete implementation of the ISubjectRepository,
    ///This layer will be changed out when the data access changes to a different method
    ///Think of it as a modular component in the system that can be "plugged in"
    /// </summary>
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IHostingEnvironment _environment;

        public SubjectRepository(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public Task<IEnumerable<Subject>> GetAllAsync()
        {
            return Task.FromResult(GetScopeDataFeedJsonData());
        }

        public Task<Subject> GetByIdAsync(string id)
        {
            return Task.FromResult(GetSingleScopeSubjectByModuleCode(id));
        }

        public Task<IEnumerable<Subject>> FindAsync(Expression<Func<Subject, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        //Returns a single TGA subject object based on the module code
        private Subject GetSingleScopeSubjectByModuleCode(string id)
        {
            Subject subjectToReturn = null;

            foreach (var subjectTransferObject in GetScopeDataFeedJsonData())
            {
                if (subjectTransferObject.ModuleCode == id)
                {
                    subjectToReturn = subjectTransferObject;
                }
            }

            return subjectToReturn;
        }

        //Returns a list of all TGA subject objects from the Mock Scope Data Feed
        private IEnumerable<Subject> GetScopeDataFeedJsonData()
        {
            string contentPath = _environment.WebRootPath;

            var json = File.ReadAllText(contentPath + "/ScopeDataFeed.json");
            var subjectList = JsonConvert.DeserializeObject<IEnumerable<Subject>>(json);
            return subjectList;
        }
    }
}
