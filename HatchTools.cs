
/*
Copyright (C) 2013  Kerry Hatcher <kwhatcher@gmail.com> Http://kerryhatcher.com

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace HatchTools
{
    public class ActiveDir
    {

        public string GetDomain()
        {

            return Environment.UserDomainName.ToString();


        }



        public bool IsInGroup(string ingroup)
        {
            string username = Environment.UserName;

            var domainctx = new PrincipalContext(ContextType.Domain, GetDomain());
            var userPrincipal = UserPrincipal.FindByIdentity(domainctx, IdentityType.SamAccountName, username);

            bool isMember = userPrincipal.IsMemberOf(domainctx, IdentityType.Name, ingroup);

            return isMember;
        }


    }
}
