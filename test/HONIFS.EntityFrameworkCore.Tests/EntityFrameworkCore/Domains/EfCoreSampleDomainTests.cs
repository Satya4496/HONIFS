using HONIFS.Samples;
using Xunit;

namespace HONIFS.EntityFrameworkCore.Domains;

[Collection(HONIFSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<HONIFSEntityFrameworkCoreTestModule>
{

}
