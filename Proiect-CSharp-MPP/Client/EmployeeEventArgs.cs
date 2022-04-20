using System;

namespace Client
{
    public enum EmployeeEvent
    {
        TicketPurchased
    };
    public class EmployeeEventArgs : EventArgs
    {
        private readonly EmployeeEvent employeeEvent;
        private readonly Object data;

        public EmployeeEventArgs(EmployeeEvent employeeEvent, object data)
        {
            this.employeeEvent = employeeEvent;
            this.data = data;
        }

        public EmployeeEvent EmployeeEventType
        {
            get { return employeeEvent; }
        }

        public object Data
        {
            get { return data; }
        }

    }
}
