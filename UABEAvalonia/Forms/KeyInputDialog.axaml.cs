using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;

namespace UABEAvalonia.Forms;

public partial class KeyInputDialog : Window
{
    public KeyInputDialog()
    {
        InitializeComponent();
        this.FindControl<TextBox>("KeyTextBox").Text = ConfigurationManager.Settings.LastUnityCNKey;
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public string Key
    {
        get { return this.FindControl<TextBox>("KeyTextBox").Text; }
    }

    private void OnOkClick(object sender, RoutedEventArgs e)
    {
        ConfigurationManager.Settings.LastUnityCNKey = Key;
        this.Close(Key);
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        this.Close(null);
    }

    public static async Task<string> ShowDialog(Window parent)
    {
        var dialog = new KeyInputDialog();
        string result = await dialog.ShowDialog<string>(parent);
        return result;
    }
}