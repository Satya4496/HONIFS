using Xunit;

namespace HONIFS.EntityFrameworkCore;

[CollectionDefinition(HONIFSTestConsts.CollectionDefinitionName)]
public class HONIFSEntityFrameworkCoreCollection : ICollectionFixture<HONIFSEntityFrameworkCoreFixture>
{

}
