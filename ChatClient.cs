using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Assignment_2
{
    [ServiceContract(CallbackContract = typeof(IChatService))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Join(string memberName);
        [OperationContract(IsOneWay = true)]
        void Leave(string memberName);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string memberName, string message);
    }

    public interface IChatChannel : IChatService, IClientChannel
    {
    }

    public partial class ChatClient : Form, IChatService
    {
        private delegate void UserJoined(string name);
        private delegate void UserSendMessage(string name, string message);
        private delegate void UserLeft(string name);

        private static event UserJoined NewJoin;
        private static event UserSendMessage MessageSent;
        private static event UserLeft RemoveUser;

        private string userName;
        private IChatChannel channel;
        private DuplexChannelFactory<IChatChannel> factory;

        private static string[] knockName = { "Says",
                                     "Water",
                                     "Nobel",
                                     "Annie",
                                     "Wa",
                                     "I am",
                                     "Haven",
                                     "Spell",
                                     "To",
                                     "Tank"
        };

        //Creating the proivate static method array string of knock knock jokes that will be sent to the client on the basis of the input from the user.
        private static string[] knockJoke = {
                                    "Says me, that's who!",
                                    "Water you asking so many questions for, just open up!",
                                    "Nobel ... that's why I knocked!",
                                    "Annie thing you can do I can better!",
                                    "What are you so excited about?!><",
                                    "Dont you even know who you are? :/",
                                    "Haven you heard enough of these knock-knock jokes?",
                                    "W-H-O!",
                                    "No, it's to whom!",
                                    "You are welcome"
        };

        private static Random randomArray = new Random();

        public ChatClient()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        public ChatClient(string userName)
        {
            this.userName = userName;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                try
                {
                    NewJoin += new UserJoined(ChatClient_NewJoin);
                    MessageSent += new UserSendMessage(ChatClient_MessageSent);
                    RemoveUser += new UserLeft(ChatClient_RemoveUser);

                    channel = null;
                    this.userName = txtUserName.Text.Trim();
                    InstanceContext context = new InstanceContext(
                        new ChatClient(txtUserName.Text.Trim()));
                    factory =
                        new DuplexChannelFactory<IChatChannel>(context, "ChatEndPoint");
                    channel = factory.CreateChannel();
                    IOnlineStatus status = channel.GetProperty<IOnlineStatus>();
                    status.Offline += new EventHandler(Offline);
                    status.Online += new EventHandler(Online);
                    channel.Open();
                    channel.Join(this.userName);
                    grpMessageWindow.Enabled = true;
                    grpUserCredentials.Enabled = false;
                    this.AcceptButton = btnSend;
                    rtbMessages.AppendText("*****************************WEL-COME to Chat Application*****************************\r\n");
                    txtSendMessage.Select();
                    txtSendMessage.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        void ChatClient_RemoveUser(string name)
        {
            try
            {
                rtbMessages.AppendText("\r\n");
                rtbMessages.AppendText(name + " left at " + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        void ChatClient_MessageSent(string name, string message)
        {
            rtbMessages.AppendText("\r\n");
            rtbMessages.AppendText(name + " says: " + message);
            string messageRec_1;

            bool ValidOuterInput = false;
            bool ValidInnerLoop = false;

            byte[] knockknockMessage = Encoding.ASCII.GetBytes("Knock Knock!");

            while (!ValidOuterInput)
            {
                messageRec_1 = string.Empty;


                messageRec_1 += message;

                if (messageRec_1 == "Who's there?")
                {
                    ValidOuterInput = true;

                    int rand = randomArray.Next(knockName.Length);

                    Console.WriteLine("Text received : {0}", messageRec_1);

                    byte[] bytesSent_1 = Encoding.ASCII.GetBytes(knockName[rand]);


                    while (!ValidInnerLoop)
                    {


                        int bytesRec_2 = message.Length;


                        {
                            ValidInnerLoop = true;

                            byte[] bytesSent_2 = Encoding.ASCII.GetBytes(knockJoke[rand]);

                        }

                        {
                            ValidInnerLoop = false;
                            byte[] messageInvalid_2 = Encoding.ASCII.GetBytes("Error:Please input a valid string -> recieved_Name + who?. \n\tFor Example: 'Sid who?'. Ask Now properly! I am knocking");
                        }
                    }
                }
                else if (messageRec_1 == "quit")
                {
                    return;

                }
                else
                {
                    Console.WriteLine("Invalid Text received : {0}", messageRec_1);
                    byte[] messageInvalid_1 = Encoding.ASCII.GetBytes("Please enter a valid response -> 'Who's there?'");
                }


            }//end of outer while loop

        }//end for loop

        public void Join(string memberName)
        {
            throw new NotImplementedException();
        }

        void IChatService.Leave(string memberName)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string memberName, string message)
        {
            throw new NotImplementedException();
        }
    
        void ChatClient_NewJoin(string name)
        {
            rtbMessages.AppendText("\r\n");
            rtbMessages.AppendText(name + " joined at: [" + DateTime.Now.ToString() + "]");
        }

        void Online(object sender, EventArgs e)
        {
            rtbMessages.AppendText("\r\nOnline: " + this.userName);
        }

        void Offline(object sender, EventArgs e)
        {
            rtbMessages.AppendText("\r\nOffline: " + this.userName);
        }

        #region IChatService Members
/*
        public void Join(string memberName)
        {
            if (NewJoin != null)
            {
                NewJoin(memberName);
            }
        }*/

        public new void Leave(string memberName)
        {
            if (RemoveUser != null)
            {
                RemoveUser(memberName);
            }
        }
/*
        public void SendMessage(string memberName, string message)
        {
            if (MessageSent != null)
            {
                MessageSent(memberName, message);
            }
        }
*/
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            channel.SendMessage(this.userName, txtSendMessage.Text.Trim());
            txtSendMessage.Clear();
            txtSendMessage.Select();
            txtSendMessage.Focus();
        }

        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (channel != null)
                {
                    channel.Leave(this.userName);
                    channel.Close();
                }
                if (factory != null)
                {
                    factory.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void grpMessageWindow_Enter(object sender, EventArgs e)
        {

        }

        private void txtSendMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbMessages_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpUserCredentials_Enter(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLoginName_Click(object sender, EventArgs e)
        {

        }

        private void grpUserList_Enter(object sender, EventArgs e)
        {

        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}