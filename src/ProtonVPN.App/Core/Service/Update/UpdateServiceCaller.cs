﻿/*
 * Copyright (c) 2023 Proton AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Threading.Tasks;
using ProtonVPN.Common.Extensions;
using ProtonVPN.Logging.Contracts;
using ProtonVPN.ProcessCommunication.Contracts;
using ProtonVPN.ProcessCommunication.Contracts.Controllers;
using ProtonVPN.ProcessCommunication.Contracts.Entities.Update;

namespace ProtonVPN.Core.Service.Update
{
    public class UpdateServiceCaller : ServiceControllerCaller<IUpdateController>
    {
        public UpdateServiceCaller(ILogger logger, IGrpcClient grpcClient, Lazy<IMonitoredVpnService> monitoredVpnService) 
            : base(logger, grpcClient, monitoredVpnService)
        {
        }

        public Task CheckForUpdates(UpdateSettingsIpcEntity updateSettingsIpcEntity)
        {
            return Invoke((c, ct) => c.CheckForUpdate(updateSettingsIpcEntity, ct).Wrap());
        }

        public Task StartAutoUpdate()
        {
            StartAutoUpdateIpcEntity startAutoUpdateIpcEntity = new()
            {
                RetryId = Guid.NewGuid()
            };
            return Invoke((c, ct) => c.StartAutoUpdate(startAutoUpdateIpcEntity, ct).Wrap());
        }
    }
}