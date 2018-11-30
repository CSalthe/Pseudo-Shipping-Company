// Program 3
// CIS 200-01
// Fall 2018
// Due: 11/12/2018
// By: Andrew L. Wright (students use Grading ID)

// File: Prog3Form.cs
// This class creates the main GUI for Program 2. It provides a
// File menu with About and Exit items, an Insert menu with Address and
// Letter items, and a Report menu with List Addresses and List Parcels
// items.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace UPVApp
{
    public partial class Prog3Form : Form
    {
        private UserParcelView upv; // The UserParcelView

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test addresses are
        //                added to the list of addresses
        public Prog3Form()
        {
            InitializeComponent();

            upv = new UserParcelView();
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand

            MessageBox.Show($"Program 3{NL}By: Andrew L. Wright{NL}CIS 200{NL}Fall 2018",
                "About Program 3");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            int zip; // Address zip code

            if (result == DialogResult.OK) // Only add if OK
            {
                if (int.TryParse(addressForm.ZipText, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip); // Use form's properties to create address
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
                                   // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // -- OR --
            // Not using StringBuilder, just use TextBox directly

            //reportTxt.Clear();
            //reportTxt.AppendText("Addresses:");
            //reportTxt.AppendText(NL); // Remember, \n doesn't always work in GUIs
            //reportTxt.AppendText(NL);

            //foreach (Address a in upv.AddressList)
            //{
            //    reportTxt.AppendText(a.ToString());
            //    reportTxt.AppendText(NL);
            //    reportTxt.AppendText("------------------------------");
            //    reportTxt.AppendText(NL);
            //}

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog
            decimal fixedCost;     // The letter's cost

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return; // Exit now since can't create valid letter
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        fixedCost); // Letter to be inserted
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
                                  // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Parcels:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                result.Append(p.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
                totalCost += p.CalcCost();
            }

            result.Append(NL);
            result.Append($"Total Cost: {totalCost:C}");

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  File, Save As menu item activated
        // Postcondition: The list of addresses is saved to a file using
        //                object serialization
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter(); // Object for serializing UPV in binary format
            FileStream output = null;                          // Stream for writing to a file
            DialogResult result;                               // Result of file dialog box
            string fileName;                                   // Name of file to save data

            using (SaveFileDialog fileChooser = new SaveFileDialog()) // Create Save File Dialog
            {
                fileChooser.CheckFileExists = false; // let user create file

                // retrieve the result of the dialog box
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specified file name
            } // end using

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {

                // show error if user specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // save file via FileStream if user specified valid file
                    try
                    {
                        // open file with write access, Create will overwrite existing file
                        output = new FileStream(fileName, FileMode.Create, FileAccess.Write);

                        formatter.Serialize(output, upv); // Serialize whole UPV object
                    } // end try
                    // handle exception if there is a problem opening the file
                    catch (IOException)
                    {
                        // notify user if file could not be opened
                        MessageBox.Show("I/O Error Writing to File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch
                    // notify user if error occurs in serialization
                    catch (SerializationException)
                    {
                        MessageBox.Show("Serialization Error Writing to File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch
                    finally
                    {
                        output?.Close(); // close FileStream if not null
                    }
                } // end else
            } // end if
        }

        // Precondition:  File, Open menu item activated
        // Postcondition: The UserParcelView is read in from a file using
        //                object deserialization, replacing the existing upv
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter reader = new BinaryFormatter(); // Object for deserializing UPV in binary format
            FileStream input = null;                        // Stream for reading from a file
            DialogResult result;                            // Result of file dialog box
            string fileName;                                // Name of file to save data
            UserParcelView temp;                            // Temporary holder for UPV

            using (OpenFileDialog fileChooser = new OpenFileDialog()) // Create Open Dialog box
            {
                result = fileChooser.ShowDialog();
                fileName = fileChooser.FileName; // get specified name
            } // end using

            // ensure that user clicked "OK"
            if (result == DialogResult.OK)
            {
                // show error if user specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // create FileStream to obtain read access to file
                    try
                    {

                        input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                        // get UPV from file
                        temp = (UserParcelView)reader.Deserialize(input);

                        upv = temp; // Separated in case deserialization failed
                    } // end try

                    // handle exception if there is a problem opening the file
                    catch (IOException)
                    {
                        // notify user if file could not be opened
                        MessageBox.Show("I/O Error Reading From File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch

                    catch (SerializationException)
                    {
                        MessageBox.Show("Serialization Error Reading From File", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } // end catch
                    finally
                    {
                        input?.Close(); // close FileStream if not null
                    }
                } // end else
            } // end if
        }

        // Precondition:  Edit, Address menu item activated
        // Postcondition: The address selected from the list has been edited
        //                with the new information replacing the existing object's
        //                properties
        private void addressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (upv.AddressList.Count > 0) // Only edit if there are addresses!
            {
                ChooseAddressForm chooseAddForm = new ChooseAddressForm(upv.AddressList); // The choose address dialog box form
                DialogResult result = chooseAddForm.ShowDialog();                         // Show form as dialog and store result

                if (result == DialogResult.OK) // Only edit if OK
                {
                    int editIndex; // Index of address to edit
                    editIndex = chooseAddForm.AddressIndex;

                    if (editIndex >= 0) // -1 if didn't select item from combo box
                    {
                        Address editAddress = upv.AddressAt(editIndex); // The address being edited
                        AddressForm addressForm = new AddressForm();    // The address dialog box form

                        // Populate form fields from selected address
                        addressForm.AddressName = editAddress.Name;
                        addressForm.Address1 = editAddress.Address1;
                        addressForm.Address2 = editAddress.Address2;
                        addressForm.City = editAddress.City;
                        addressForm.State = editAddress.State;
                        addressForm.ZipText = $"{editAddress.Zip:D5}";

                        result = addressForm.ShowDialog(); // Show form as dialog and store result

                        if (result == DialogResult.OK) // Only edit if OK
                        {
                            // Edit address properties using form fields
                            editAddress.Name = addressForm.AddressName;
                            editAddress.Address1 = addressForm.Address1;
                            editAddress.Address2 = addressForm.Address2;
                            editAddress.City = addressForm.City;
                            editAddress.State = addressForm.State;
                            if (int.TryParse(addressForm.ZipText, out int zip))
                            {
                                editAddress.Zip = zip;
                            }
                            else
                            {
                                MessageBox.Show("Problem with Zip Validation!", "Validation Error");
                            }
                        }
                        addressForm.Dispose(); // Best practice for dialog boxes
                    }
                }
                chooseAddForm.Dispose(); // Best practice for dialog boxes
            }
            else
                MessageBox.Show("No addresses to edit!", "No Addresses");
        }
    }
}