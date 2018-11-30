// Program 3
// CIS 200-01
// Fall 2018
// Due: 11/12/2018
// By: Andrew L. Wright (students use Grading ID)

// File: ChooseAddressForm.cs
// This class creates the Choose Address to Edit dialog box form GUI. It
// provides a get property to retrieve the index of the selected Letter
// from a list of addresses.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class ChooseAddressForm : Form
    {
        private List<Address> addressList; // List of addresses used to fill combo boxes

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display.
        public ChooseAddressForm(List<Address> addresses)
        {
            InitializeComponent();
            addressList = addresses;
        }

        public int AddressIndex
        {
            // Precondition:  User has selected from originAddCbo
            // Postcondition: The index of the selected origin address returned
            get
            {
                return addListCbo.SelectedIndex;
            }

            // Precondition:  -1 <= value < addressList.Count
            // Postcondition: The specified index is selected in originAddCbo
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    addListCbo.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("AddressIndex", value,
                        "Index must be valid");
            }
        }


        // Precondition:  None
        // Postcondition: The list of addresses is used to populate the
        //                list of addresses combo boxes
        private void ChooseAddressForm_Load(object sender, EventArgs e)
        {
            foreach (Address a in addressList)
            {
                addListCbo.Items.Add(a.Name);
            }

            addListCbo.SelectedIndex = 0; // Select first name in list
        }

        // Precondition:  User pressed on cancelBtn
        // Postcondition: Form closes
        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            // This handler uses MouseDown instead of Click event because
            // Click won't be allowed if other field's validation fails

            this.DialogResult = DialogResult.Cancel;
        }

        // Precondition:  Focus shifting from addListCbo
        // Postcondition: If no address selected, focus remains and error provider
        //                highlights the field
        private void addListCbo_Validating(object sender, CancelEventArgs e)
        {
            if (addListCbo.SelectedIndex == -1) // -1 means no item selected
            {
                e.Cancel = true;
                errorProvider.SetError(addListCbo, "Must select an address");
            }
        }

        // Precondition:  Validating of addListCbo not cancelled, so data OK
        // Postcondition: Error provider cleared and focus allowed to change
        private void addListCbo_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(addListCbo, "");
        }

        // Precondition:  User clicked on okBtn
        // Postcondition: If invalid field on dialog, keep form open and give first invalid
        //                field the focus. Else return OK and close form.
        private void okBtn_Click(object sender, EventArgs e)
        {
            // The easy way
            // Raise validating event for all enabled controls on form
            // If all pass, ValidateChildren() will be true
            if (ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }
    }
}
