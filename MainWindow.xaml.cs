using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Labs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void CanExecute_DeleteText(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(TextBox1.Text);
        }

        private void Execute_DeleteText(object sender, ExecutedRoutedEventArgs e)
        {
            TextBox1.Clear();
        }

        private void Execute_Close(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CanExecute_Answer(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(TextBox1.Text);
        }

        private readonly string[] answers = { "Так", "Ні", "Скоріше так", "Скоріше ні" };
        private void Execute_Answer(object sender, ExecutedRoutedEventArgs e)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, answers.Length);
            Answer.Content = answers[index];
        }

        public static RoutedUICommand AnswerCommand = new RoutedUICommand("Answer", "Answer", typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();

            CommandBinding closeCommand = new CommandBinding(ApplicationCommands.Close, Execute_Close);
            CommandBindings.Add(closeCommand);

            CommandBinding answerCommand = new CommandBinding(AnswerCommand, Execute_Answer, CanExecute_Answer);
            CommandBindings.Add(answerCommand);

            CommandBinding deleteCommand = new CommandBinding(ApplicationCommands.Delete, Execute_DeleteText, CanExecute_DeleteText);
            CommandBindings.Add(deleteCommand);

        }

    }
}