using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Booking
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hotelsSetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hotelsSetViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // hotelsSetViewSource.Source = [source de données générique]
            System.Windows.Data.CollectionViewSource chambresSetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("chambresSetViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // chambresSetViewSource.Source = [source de données générique]
            System.Windows.Data.CollectionViewSource clientsSetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientsSetViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // clientsSetViewSource.Source = [source de données générique]
            System.Windows.Data.CollectionViewSource reservationSetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reservationSetViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // reservationSetViewSource.Source = [source de données générique]
        }

        /// <summary>
        /// Add Hotel
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.Booking())
            {
                HotelsSet hotel = new HotelsSet();
                hotel.Nom = nomTextBox.Text;
                hotel.Capacite = Int32.Parse(capaciteTextBox.Text);
                hotel.Localisation = localisationTextBox.Text;
                hotel.Pays = paysTextBox.Text;

                db.HotelsSet.Add(hotel);
                db.SaveChanges();
            }

            DisplayHotels();
        }

        /// <summary>
        /// Add client
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.Booking())
            {
                ClientsSet client = new ClientsSet();
                client.Nom = nomTextBox1.Text;
                client.Prenom = prenomTextBox.Text;
                client.DateNaissance = dateNaissanceDatePicker.DisplayDate;

                db.ClientsSet.Add(client);
                db.SaveChanges();
            }

            DisplayUsers();
        }

        private void dateNaissanceDatePicker_GotFocus(object sender, RoutedEventArgs e)
        {
            DisplayUsers();
        }

        #region DisplayModels
        private void DisplayUsers()
        {
            using (var db = new Model.Booking())
            {
                List<ClientsSet> clientsResult = (from clients in db.ClientsSet select clients).ToList();
                clientsSetDataGrid.ItemsSource = clientsResult;
            }
        }

        private void DisplayHotels()
        {
            using (var db = new Model.Booking())
            {
                List<HotelsSet> hotelResult = (from hotel in db.HotelsSet select hotel).ToList();
                hotelsSetDataGrid.ItemsSource = hotelResult;
            }
        }

        private void DisplayChambres()
        {
            using (var db = new Model.Booking())
            {
                List<ChambresSet> chambreResult = (from chambre in db.ChambresSet select chambre).ToList();
                chambresSetDataGrid.ItemsSource = chambreResult;
            }
        }

        private void DisplayReservations()
        {
            using (var db = new Model.Booking())
            {
                List<ReservationSet> reservationsResult = (from reserv in db.ReservationSet select reserv).ToList();
                reservationSetDataGrid.ItemsSource = reservationsResult;
            }
        }
        #endregion

        private void TabItem_Initialized(object sender, EventArgs e)
        {
            DisplayHotels();
        }

        private void TabItem_Initialized_1(object sender, EventArgs e)
        {
            DisplayUsers();
        }

        private void TabItem_Initialized_2(object sender, EventArgs e)
        {
            DisplayChambres();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (clientsSetDataGrid.SelectedItem != null)
            {
                clientsSetDataGrid.Items.Remove((ClientsSet)clientsSetDataGrid.SelectedItem);
            }
        }

        /// <summary>
        /// Add chambres
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.Booking())
            {
                bool isClim = false;
                if (climatisationCheckBox.IsChecked.Value)
                {
                    isClim = true;
                }

                ChambresSet chambre = new ChambresSet();
                chambre.Nom = nomTextBox2.Text;
                chambre.Climatisation = isClim;
                chambre.NbLits = Int32.Parse(nbLitsTextBox.Text);
                chambre.HotelsSetId = hotelChambreID.SelectedIndex;

                db.ChambresSet.Add(chambre);
                db.SaveChanges();
            }

            DisplayChambres();
        }

        /// <summary>
        /// Add reservation
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.Booking())
            {
                ReservationSet reserv = new ReservationSet();
                reserv.ChambresSetId = chambreCombo.SelectedIndex;
                reserv.ClientsSetId = clientCombo.SelectedIndex;
                reserv.dateDebut = dateDebutDatePicker.DisplayDate.Date;
                reserv.dateFin = dateFinDatePicker.DisplayDate.Date;

                db.ReservationSet.Add(reserv);
                db.SaveChanges();
            }

            DisplayReservations();
        }

        #region Launch Exception
        private void LaunchException(Exception ex)
        {

        }
        #endregion

        #region Initialize combo box
        /// <summary>
        /// Initialize chambre dropdown
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        ///                          XX/XX/XXXX | X.XXX (SESAXXXXX)      
        /// =====================================================================================
        private void hotelChambreID_Initialized(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Model.Booking())
                {
                    List<int> hotelIds = (from hotel in db.HotelsSet select hotel.Id).ToList();


                    foreach (var item in hotelIds)
                    {
                        hotelChambreID.Items.Add(item.ToString());
                    }
                }
            }
            catch (SystemException ex)
            {

            }
        }

        private void chambreCombo_Initialized(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Model.Booking())
                {
                    List<int> chambreID = (from chambre in db.ChambresSet select chambre.Id).ToList();


                    foreach (var item in chambreID)
                    {
                        chambreCombo.Items.Add(item.ToString());
                    }
                }
            }
            catch (SystemException ex)
            {

            }
        }

        private void clientCombo_Initialized(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Model.Booking())
                {
                    List<int> clients = (from cli in db.ClientsSet select cli.Id).ToList();


                    foreach (var item in clients)
                    {
                        clientCombo.Items.Add(item.ToString());
                    }
                }
            }
            catch (SystemException ex)
            {

            }
        }
        #endregion

        #region Delete update datagrids
        /// <summary>
        /// delete row from datagrid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// =====================================================================================
        /// Modification : Initial : 25/10/2018 |N.Wilcké (SESA474351)
        /// =====================================================================================
        private void deleteHotelRow_Click(object sender, RoutedEventArgs e)
        {
            if (hotelsSetDataGrid.SelectedItem != null)
            {

            }
        }
        #endregion
    }
}
