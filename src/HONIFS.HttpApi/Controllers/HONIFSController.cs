﻿using HONIFS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HONIFS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HONIFSController : AbpControllerBase
{
    protected HONIFSController()
    {
        LocalizationResource = typeof(HONIFSResource);
    }
}
