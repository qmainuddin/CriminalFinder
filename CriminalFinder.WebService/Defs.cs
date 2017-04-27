using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalFinder.WebService
{
    public class Defs
    {
        public const String ERROR_PARAMETER_CONTAINS_NULL = "You have passed null parameter";
        public const String ERROR_DATABASE_IS_DOWN = "Currently the database is down.";
        public const String ERROR_DATA_NOT_FOUND = "No Data Found";
        public const String ERROR_CREATE_OPERATION_IS_FAILED = "Create operation is failed";
        public const String ERROR_UPDATE_OPERATION_IS_FAILED = "Updaet operation is failed";
        public const String ERROR_DELETE_OPERATION_IS_FAILED = "Delete operation is failed";
        public const String ERROR_OPERATION_IS_FAILED = "Operation is failed";
    }
}