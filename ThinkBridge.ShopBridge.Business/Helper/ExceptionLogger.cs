using System;

namespace ThinkBridge.ShopBridge.Business.Helper
{
   public class ExceptionLogger
    {
        //Self instance
        private static ExceptionLogger instance;
        private static object syncRoot = new Object();

        /// <summary>
        /// public default parameterless constructor
        /// </summary>
        private ExceptionLogger()
        {
            //Do nothing.
        }

        /// <summary>
        /// Property to hold the Instance of the class <see cref="MindTree.PeopleHub.Ess.Expense.ExceptionLogger"/>
        /// </summary>
        public static ExceptionLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ExceptionLogger();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Logs the exception into Data Base table.
        /// </summary>
        /// <param name="exception">Object of type <see cref="System.Exception"/></param>
        /// <param name="pageName">Name of the Control</param>
        /// <param name="methodName">Name of the Action Method</param>
        public void Log(Exception exception, string controlName, string actionMethodName, int currentUserId)
        {
            try
            {
                //UOWKalingaRBS uow = new UOWKalingaRBS();
                //uow.ErrorLog.Add(new AMS_ErrorLogs() { LoggedById = currentUserId, LoggedOn = DateTime.Now, Message = exception.ToString(), MethodName = actionMethodName, PageName = controlName });
                //uow.Commit();
            }
            catch
            {
                //Do nothing :( thats bad :( :(
            }
        }
    }
}
