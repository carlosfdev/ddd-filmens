using System.Collections.Generic;
using Filmens.Core.ProjectAggregate;

namespace Filmens.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
