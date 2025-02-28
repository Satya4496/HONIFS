using HONIFS.Samples;
using Xunit;

namespace HONIFS.EntityFrameworkCore.Applications;

[Collection(HONIFSTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<HONIFSEntityFrameworkCoreTestModule>
{

}
