using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class InforUser : Form
    {
        public InforUser()
        {
            InitializeComponent();
        }

        private User_BUS user = new User_BUS();

        private void InforUser_Load(object sender, EventArgs e)
        {
            try
            {
                Cafe_Management cafe = new Cafe_Management();

                var userInfo = user.GetInfor(cafe.name);

                if (userInfo != null)
                {
                    lbName.Text = userInfo.FullName;
                    lbPhone.Text = userInfo.Phone;
                    lbCard.Text = userInfo.IdentityCard;
                    lbRole.Text = userInfo.Role;
                }
                else
                {
                    lbName.Text = "User not found";
                    lbPhone.Text = string.Empty;
                    lbCard.Text = string.Empty;
                    lbRole.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

    }
}
