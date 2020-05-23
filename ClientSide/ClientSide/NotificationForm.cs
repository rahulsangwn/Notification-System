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
        ClientSocket _socket;

        public NotificationForm(ClientSocket socket)
        {
            _socket = socket;
            InitializeComponent();
            dateDataGridViewTextBoxColumn.ReadOnly = true;
        }

        public void SetInfo(string mode, string identity)
        {
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
                notificationEntityBindingSource.RemoveCurrent();
            }
        }
    }
}
