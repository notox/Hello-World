using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using FujiMedical.Desktop.Setting;


namespace FujiMedical.Setting.View.WinForms
{
	public partial class CommunicationConfigControl : UserControl
	{
		public CommunicationConfigControl()
		{
			InitializeComponent();
		}

		public event EventHandler CEchoTestEvent
		{
			add {
				btnEcho.Click += value;
			}
			remove {
				btnEcho.Click -= value;
			}
		}
		private void InitializeView()
		{
			//txtCalledAETitle.Text = setting.CalledAET;
			//txtAETitle.Text = setting.AETitle;
			//txtPoint.Text = setting.Port.ToString();

			//string strIP = setting.Peer;
			//string[] IPaddress = strIP.Split('.');
			//if (IPaddress.Length == 4)
			//{
			//    txtIp1.Text = IPaddress[0];
			//    txtIp2.Text = IPaddress[1];
			//    txtIp3.Text = IPaddress[2];
			//    txtIp4.Text = IPaddress[3];
			//}

			////cbxTransfer.Items.Add(SR.OriginalImage);
			////cbxTransfer.Items.Add(SR.JPEGLSImage);
			//cbxTransfer.SelectedIndex = Setting.Compression;
		}
		public string Host
		{
			get {
				return string.Format("{0}.{1}.{2}.{3}", txtIp1.Text, txtIp2.Text, txtIp3.Text, txtIp4.Text);
			}
		}
		public Int32 Port
		{
			get {
				return Convert.ToInt32(txtPoint.Text);
			}
		}
		public string LocalAET
		{
			get {
				return txtAETitle.Text;
			}
		}
		public string RemoteAET
		{
			get {
				return txtCalledAETitle.Text;
			}
		}
		public void Save()
		{
			//if (Setting != null)
			//{
			//    Setting.CalledAET = this.RemoteAET;
			//    Setting.AETitle = this.LocalAET;
			//    Setting.Port = this.Port;
			//    Setting.Peer = this.Host;
			//    Setting.Compression = cbxTransfer.SelectedIndex;
			//}
		}
		
	}
}
