﻿/*
 * Copyright (c) 2020 Proton Technologies AG
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtonVPN.UI.Test.Pages;
using ProtonVPN.UI.Test.TestsHelper;

namespace ProtonVPN.UI.Test.Tests
{
    [TestClass]
    public class AccountTests : UITestSession
    {
        [TestMethod]
        public void CheckIfUsernameIsDisplayedInAccountSection()
        {
            var loginWindow = new LoginWindow();
            loginWindow.LoginWithPlusUser();

            var mainWindow = new MainWindow();
            mainWindow.ClickHamburgerMenu().HamburgerMenu.ClickAccount();

            RefreshSession();
            var accountWindow = new AccountWindow();
            accountWindow.VerifyLoggedInAsTextIs(TestUserData.GetPlusUser().Username);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            CreateSession();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TearDown();
        }
    }
}
