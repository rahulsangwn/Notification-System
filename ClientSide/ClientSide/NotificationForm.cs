using ClientSide.Data;
using ClientSide.Socket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class NotificationForm : Form
    {
        IClientSocket _socket;
        ISocketManager _manager;
        IDataExtraction _data;
        string _mode;
        string _identity;

        public NotificationForm(IClientSocket socket, ISocketManager manager, IDataExtraction data)
        {
            _socket = socket;
            _manager = manager;
            _data = data;
            InitializeComponent();
            dateDataGridViewTextBoxColumn.ReadOnly = true;
            _data.NewNotification += NewNotificationReceived;
        }

        private void NewNotificationReceived(object sender, INotificationEntity e)
        {
            var notification = e;
            
            notificationEntityBindingSource.DataSource = null;
            notificationEntityBindingSource.DataSource = NotificationData.GetAll();
            
        }

        public void SetInfo(string mode, string identity)
        {
            _mode = mode;
            _identity = identity;
            labelInfo.Text = mode + ": " + identity;
        }

        internal void ClearData()
        {
            NotificationData.Clear();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            foreach (var notification in NotificationData.GetAll())
            {
                notificationEntityBindingSource.Add(notification);
            }
        }

        private void dataGridViewNotification_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewNotification.Columns[e.ColumnIndex].Name == "Clear")
            {
                var notification = dataGridViewNotification.Rows[e.RowIndex].Cells[1].Value.ToString();
                var notificationId = NotificationData.GetId(notification);
                string clearReq = "Clear:" + _mode + ":" + _identity + ":" + notificationId;
                _manager.SendData(clearReq);
                notificationEntityBindingSource.RemoveCurrent();
            }
        }
    }
}
