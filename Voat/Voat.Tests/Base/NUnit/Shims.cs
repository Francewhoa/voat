#region LICENSE

/*
    
    Copyright(c) Voat, Inc.

    This file is part of Voat.

    This source file is subject to version 3 of the GPL license,
    that is bundled with this package in the file LICENSE, and is
    available online at http://www.gnu.org/licenses/gpl-3.0.txt;
    you may not use this file except in compliance with the License.

    Software distributed under the License is distributed on an
    "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express
    or implied. See the License for the specific language governing
    rights and limitations under the License.

    All Rights Reserved.

*/

#endregion LICENSE

using System;
using System.Collections;
using System.Threading.Tasks;
using Voat.Domain.Command;

//This is a start of a port to NUnit, the idea was to originally support both NUnit and MSTest, 
//but MSTest is written so wacky it can not be cleanly abstracted without a lot of plumbing code,
//so we are ditching it entirely, and eventually this attribute shim will go away.
namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
#if NUNIT
    public class TestClassAttribute : NUnit.Framework.TestFixtureAttribute
    {
    }
    public class TestInitializeAttribute : NUnit.Framework.SetUpAttribute
    {
    }
    public class TestMethodAttribute : NUnit.Framework.TestAttribute
    {
    }
    public class IgnoreAttribute : NUnit.Framework.IgnoreAttribute
    {
        public IgnoreAttribute(string reason = null) : base(reason) { }
    }

    public class TestCategoryAttribute : NUnit.Framework.CategoryAttribute
    {
        public TestCategoryAttribute(string name) : base(name) { }
    }

    [Obsolete("Not portable to NUnit", true)]
    public class ExpectedExceptionAttribute : Attribute
    {
        public ExpectedExceptionAttribute(Type expectedType) { }
    }

    public class AssemblyInitializeAttribute : Attribute
    {

    }
   
    public class ClassInitializeAttribute : NUnit.Framework.OneTimeSetUpAttribute
    {

    }
    public class TestContext : NUnit.Framework.TestContext
    {
        public TestContext(IDictionary dictionary) : base(new NUnit.Framework.Internal.TestExecutionContext())
        {
            //THIS IS WRONG
        }
    }

    //[Obsolete("Not portable to NUnit", true)]
    //public class ClassInitializeAttribute : Attribute
    //{

    //}
    //public class AssemblyCleanupAttribute : NUnit.Framework.PostTestAttribute
    //{

    //}
    //public class ExpectedExceptionAttribute : NUnit.Framework.ExpectedExceptionAttribute
    //{
    //    public ExpectedExceptionAttribute(Type exceptionType) : this(exceptionType, null)
    //    {
    //    }
    //    public ExpectedExceptionAttribute(Type exceptionType, string message) : base(exceptionType)
    //    {
    //        UserMessage = message;
    //    }
    //}
     public class Assert : NUnit.Framework.Assert
    {

    }
#else
    public static class VoatAssert
    {
        public static async Task ThrowsAsync<T>(Func<Task> func) where T: Exception
        {
            await Assert.ThrowsExceptionAsync<T>(func);

        }
        public static void Throws<T>(Action action) where T : Exception
        {
            Assert.ThrowsException<T>(action);
        }
        public static void IsValid<T>(CommandResponse<T> response, Status status = Status.Success, string message = null)
        {
            IsValid((CommandResponse)response, status, message);
            if (status == Status.Success)
            {
                Assert.IsNotNull(response.Response, message ?? "Command response is null");
            }
        }
        public static void IsValid(CommandResponse response, Status status = Status.Success, string message = null)
        {
            Assert.IsNotNull(response, message ?? "CommandResponse is null");

            if (response.Exception != null)
            {
                throw response.Exception;
            }
            else if (response.Status != status)
            {
                Assert.Fail(message?? response.Message);
            }
        }
    } 
#endif


}

