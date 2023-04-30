using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cash_Flow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private int playerCount;
        private int jobChooseTurn;
        private List<Job> jobs;
        private Random rand;
        private List<Player> pList;
        private int currentPage;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Menu";
            showMenu();
            jobSelection.Visibility= Visibility.Hidden;
            gameSetupCan.Visibility = Visibility.Hidden;
            playerCount= 0;
            DooDad d = new DooDad("NEW GOLF CLUBS", 800);
            jobChooseTurn = 1;
            jobs = new List<Job>();
            rand = new Random();
            currentPage = 0;
        }

        private void howToPlayButton_Click(object sender, RoutedEventArgs e)
        {
            howToPlayCanvas.Visibility= Visibility.Visible;
            startButton.IsEnabled= false;
            howToPlayButton.IsEnabled = false;
            quitButton.IsEnabled= false;
            rulesBlock.Text = "To win you must get your cashflow over\n your total expenses.";
            rulesBlock.Text += " You can achieve this by buying\n and selling property/stocks";
        }

        private void hideMenu()
        {
            mainMenu.Visibility = Visibility.Hidden;
        }
        private void showMenu()
        {
            mainMenu.Visibility = Visibility.Visible;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            hideMenu();
            currentPage++;
            showNextBackButt();
            gameSetupCan.Visibility = Visibility.Visible;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentPage == 1)
            {
                showMenu();
                gameSetupCan.Visibility = Visibility.Hidden;
                hideNextBackButt();
            }
            else if(currentPage == 2)
            {
                gameSetupCan.Visibility = Visibility.Visible;
                jobSelection.Visibility = Visibility.Hidden;
                nextButton.Content = "Next";
            }

            currentPage--;
        }

        private void addPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if(playerCount == 0)
            {
                p1Label.Visibility = Visibility.Visible;
                p1NickLabel.Visibility = Visibility.Visible;
                p1TextBox.Visibility = Visibility.Visible;
                removePlayerButton.IsEnabled = true;
                playerCount++;
            }
            else if(playerCount == 1)
            {
                p2Label.Visibility = Visibility.Visible;
                p2NickLabel.Visibility = Visibility.Visible;
                p2TextBox.Visibility = Visibility.Visible;
                playerCount++;
            }
            else if (playerCount == 2)
            {
                p3Label.Visibility = Visibility.Visible;
                p3NickLabel.Visibility = Visibility.Visible;
                p3TextBox.Visibility = Visibility.Visible;
                playerCount++;
            }
            else if(playerCount == 3)
            {
                p4Label.Visibility = Visibility.Visible;
                p4NickLabel.Visibility = Visibility.Visible;
                p4TextBox.Visibility = Visibility.Visible;
                addPlayerButton.IsEnabled = false;
                playerCount++;
            }
        }

        private void removePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if(playerCount ==4)
            {
                p4Label.Visibility = Visibility.Hidden;
                p4NickLabel.Visibility = Visibility.Hidden;
                p4TextBox.Visibility = Visibility.Hidden;
                p4TextBox.Text = string.Empty;
                addPlayerButton.IsEnabled = true;
                playerCount--;
            }
            else if (playerCount == 3)
            {
                p3Label.Visibility = Visibility.Hidden;
                p3NickLabel.Visibility = Visibility.Hidden;
                p3TextBox.Visibility = Visibility.Hidden;
                p3TextBox.Text = string.Empty;
                addPlayerButton.IsEnabled = true;
                playerCount--;
            }
            else if (playerCount == 2)
            {
                p2Label.Visibility = Visibility.Hidden;
                p2NickLabel.Visibility = Visibility.Hidden;
                p2TextBox.Visibility = Visibility.Hidden;
                p2TextBox.Text = string.Empty;
                addPlayerButton.IsEnabled = true;
                playerCount--;
            }
            else if (playerCount == 1)
            {
                p1Label.Visibility = Visibility.Hidden;
                p1NickLabel.Visibility = Visibility.Hidden;
                p1TextBox.Visibility = Visibility.Hidden;
                playerCount--;
                p1TextBox.Text = string.Empty;
                removePlayerButton.IsEnabled = false;
                addPlayerButton.IsEnabled = true;
            }
        }
        private void populateJobs()
        {
            Job Doctor = new Job("Doctor", 13200, 8300, 4900, 3500, 0);
            Job Mechanic = new Job("Mechanic", 2000, 1300, 700, 700, 0);
            Job Engineer = new Job("Engineer", 4900, 3200, 1700, 400, 0);
            Job Janitor = new Job("Janitor", 1600, 1000, 600, 600,0);
            jobs.Add(Doctor);
            jobs.Add(Mechanic);
            jobs.Add(Engineer);
            jobs.Add(Janitor);
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
          
            if(currentPage == 1)
            {
                pList = new List<Player>();
                Player player;
                for(int i = 1; i <= playerCount; i++)
                {
                    if(i == 1)
                    {
                        player = new Player(p1TextBox.Text);
                        pList.Add(player);
                    }
                    else if(i == 2)
                    {
                        player = new Player(p2TextBox.Text);
                        pList.Add(player);
                    }
                    else if(i == 3)
                    {
                        player = new Player(p3TextBox.Text);
                        pList.Add(player);
                    }
                    else if(i == 4)
                    {
                        player = new Player(p4TextBox.Text);
                        pList.Add(player);
                    }
                }
                nextButton.Content = "Start";
                gameSetupCan.Visibility = Visibility.Hidden;
                jobSelection.Visibility = Visibility.Visible;
                
                populateJobs();
                
            }
            else if(currentPage == 2)
            {
                reset();
                hideNextBackButt();
                showMenu();
                jobSelection.Visibility = Visibility.Hidden;
                currentPage = 0;
                game game = new game();
                game.set(pList);
                game.ShowDialog();
            }
            currentPage++;
        }
        public void reset()
        {
            p1TextBox.Text = string.Empty;
            p2TextBox.Text = string.Empty;
            p3TextBox.Text = string.Empty;  p4TextBox.Text = string.Empty;
            piece1.Source = null;
            piece2.Source = null;
                piece3.Source = null;
            piece4.Source = null;
            playerCount = 1;
            p2Label.Visibility= Visibility.Hidden;
            p2NickLabel.Visibility= Visibility.Hidden;
            p2TextBox.Visibility= Visibility.Hidden;
            p3Label.Visibility= Visibility.Hidden;
            p3NickLabel.Visibility= Visibility.Hidden;
            p3TextBox.Visibility= Visibility.Hidden;
            p4NickLabel.Visibility= Visibility.Hidden;
            p4Label.Visibility= Visibility.Hidden; 
            p4TextBox.Visibility= Visibility.Hidden;

        }
        public void hideNextBackButt()
        {
            nextButton.Visibility = Visibility.Hidden;
            backButton.Visibility = Visibility.Hidden;
        }
        public void showNextBackButt()
        {
            nextButton.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Visible;
        }
        private void job1_Click(object sender, RoutedEventArgs e)
        {
            if (jobChooseTurn == playerCount)
            {
                disableAllJobs();
            }
            int n = rand.Next(0,jobs.Count);
            pList[jobChooseTurn - 1].setJob(jobs[n]);
            job1.Content = jobs[n].toString();
            jobs.RemoveAt(n);
            if (jobChooseTurn == 1)
            {
                piece1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p1piece.png"));
                job1.IsEnabled = false;
                jobChooseTurn++;
                
            }
            else if(jobChooseTurn == 2)
            {
                piece1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p2piece.png"));
                job1.IsEnabled = false;
                jobChooseTurn++;
            }
            else if(jobChooseTurn == 3)
            {
                piece1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p3piece.png"));
                job1.IsEnabled = false;
                jobChooseTurn++;
            }
            else if(jobChooseTurn == 4)
            {
                piece1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p4piece.png"));
                job1.IsEnabled = false;
                nextButton.IsEnabled = true;
            }
            if (jobChooseTurn <= playerCount)
            {
                turnLabel.Content = "Player " + jobChooseTurn + "'s turn";
            }
        }

        private void job2_Click(object sender, RoutedEventArgs e)
        {
            if (jobChooseTurn == playerCount)
            {
                disableAllJobs();
            }
            int n = rand.Next(0, jobs.Count);
            pList[jobChooseTurn - 1].setJob(jobs[n]);
            job2.Content = jobs[n].toString();
            jobs.RemoveAt(n);
            Debug.WriteLine("N: " + n);
            if (jobChooseTurn == 1)
            {
                piece2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p1piece.png"));
                job2.IsEnabled = false;
                jobChooseTurn++;
            }
            else if (jobChooseTurn == 2)
            {
                piece2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p2piece.png"));
                job2.IsEnabled = false;
                jobChooseTurn++;
            }
            else if (jobChooseTurn == 3)
            {
                piece2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p3piece.png"));
                job2.IsEnabled = false;
                jobChooseTurn++;
            }
            else if (jobChooseTurn == 4)
            {
                piece2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p4piece.png"));
                job2.IsEnabled = false;
                nextButton.IsEnabled = true;
            }

            if (jobChooseTurn <= playerCount)
            {
                turnLabel.Content = "Player " + jobChooseTurn + "'s turn";
            }

        }

        private void job3_Click(object sender, RoutedEventArgs e)
        {
            if (jobChooseTurn == playerCount)
            {
                disableAllJobs();
            }
            int n = rand.Next(0, jobs.Count);
            pList[jobChooseTurn - 1].setJob(jobs[n]);
            job3.Content = jobs[n].toString();
            jobs.RemoveAt(n);
            Debug.WriteLine("N: " + n);
            if (jobChooseTurn == 1)
            {
                piece3.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p1piece.png"));
                job3.IsEnabled = false;
                jobChooseTurn++;
            }
            else if (jobChooseTurn == 2)
            {
                piece3.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p2piece.png"));
                job3.IsEnabled = false;
                jobChooseTurn++;
            }
            else if (jobChooseTurn == 3)
            {
                piece3.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p3piece.png"));
                job3.IsEnabled = false;
                jobChooseTurn++;
            }
            else if (jobChooseTurn == 4)
            {
                piece3.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p4piece.png"));
                job3.IsEnabled = false;
                nextButton.IsEnabled = true;
            }

            if (jobChooseTurn <= playerCount)
            {
                turnLabel.Content = "Player " + jobChooseTurn + "'s turn";
            }

        }

        private void job4_Click(object sender, RoutedEventArgs e)
        {
            if(jobChooseTurn == playerCount)
            {
                disableAllJobs();
            }
            int n = rand.Next(0, jobs.Count);
            job4.Content = jobs[n].toString();
            pList[jobChooseTurn - 1].setJob(jobs[n]);
            jobs.RemoveAt(n);
            if (jobChooseTurn == 1)
            {
                piece4.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p1piece.png"));
                job4.IsEnabled = false;
                jobChooseTurn++;
            }
            else if (jobChooseTurn == 2)
            {
                piece4.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p2piece.png"));
                job4.IsEnabled = false;
                jobChooseTurn++;
            }
            else if (jobChooseTurn == 3)
            {
                piece4.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p3piece.png"));
                job4.IsEnabled = false;
                jobChooseTurn++;
            }
            else if (jobChooseTurn == 4)
            {
                piece4.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Img\\p4piece.png"));
                job4.IsEnabled = false;
                nextButton.IsEnabled = true;
            }

            if (jobChooseTurn <= playerCount)
            {
                turnLabel.Content = "Player " + jobChooseTurn + "'s turn";
            }


        }
        public void disableAllJobs()
        {
            job1.IsEnabled = false;
            job2.IsEnabled = false;
            job3.IsEnabled = false;
            job4.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            howToPlayCanvas.Visibility = Visibility.Hidden;
            startButton.IsEnabled= true;
            howToPlayButton.IsEnabled= true;
            quitButton.IsEnabled= true;
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
