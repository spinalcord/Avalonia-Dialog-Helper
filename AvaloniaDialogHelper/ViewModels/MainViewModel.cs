using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;
using System.Diagnostics;
using System.IO;
using System.Reactive;
using System.Reflection;

namespace AvaloniaDialogHelper.ViewModels;

public class MainViewModel : ViewModelBase
{

    public MainViewModel() 
    {
        GenerateOutput = ReactiveCommand.Create(GenerateOutputCommand);
    }

    string dialogOwner = "MainWindow";
    
    public string DialogOwner
    {
        get
        {
            return dialogOwner;
        }
    
        set
        {
            this.RaiseAndSetIfChanged(ref dialogOwner, value);
        }
    }

    string viewModelSender = "MainViewModel";
    
    public string ViewModelSender
    {
        get
        {
            return viewModelSender;
        }
    
        set
        {
            this.RaiseAndSetIfChanged(ref viewModelSender, value);
        }
    }


    string nameOfDialogsView = "SampleDialogView";
    
    public string NameOfDialogsView
    {
        get
        {
            return nameOfDialogsView;
        }
    
        set
        {
            this.RaiseAndSetIfChanged(ref nameOfDialogsView,value);
        }
    }

    string nameOfDialogsViewModel = "SampleDialogViewModel";
    
    public string NameOfDialogsViewModel
    {
        get
        {
            return nameOfDialogsViewModel;
        }
    
        set
        {
            this.RaiseAndSetIfChanged(ref nameOfDialogsViewModel, value);
        }
    }


    string returnType = "string";
    
    public string ReturnType
    {
        get
        {
            return returnType;
        }
    
        set
        {
            returnType = value;
        }
    }

    string commandName = "MyButtonOpensADialog";
    
    public string CommandName
    {
        get
        {
            return commandName;
        }
    
        set
        {
            commandName = value;
        }
    }


    string dialogOwnerTemplate = "";
    public string DialogOwnerTemplate
    {
        get
        {
            return dialogOwnerTemplate;
        }
    
        set
        {
            this.RaiseAndSetIfChanged(ref dialogOwnerTemplate, value);
        }
    }


    string viewModelSenderTemplate;
    
    public string ViewModelSenderTemplate
    {
        get
        {
            return viewModelSenderTemplate;
        }
    
        set
        {
            this.RaiseAndSetIfChanged(ref viewModelSenderTemplate, value);
        }
    }


    string nameOfDialogsViewTemplate;
    
    public string NameOfDialogsViewTemplate
    {
        get
        {
            return nameOfDialogsViewTemplate;
        }
    
        set
        {
            this.RaiseAndSetIfChanged( ref nameOfDialogsViewTemplate, value);
        }
    }

    string nameOfDialogsViewModelTemplate;
    
    public string NameOfDialogsViewModelTemplate
    {
        get
        {
            return nameOfDialogsViewModelTemplate;
        }
    
        set
        {
            this.RaiseAndSetIfChanged(ref nameOfDialogsViewModelTemplate, value);
        }
    }

    public string ReadTemplate(string name)
    {
        var a = AssetLoader.Open(new System.Uri("avares://AvaloniaDialogHelper/Assets/"+name), null);

        string output = "";

        using (StreamReader sr = new StreamReader(a))
        {
            output = sr.ReadToEnd();
            

            foreach(PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                output = output.Replace("{" + propertyInfo.Name + "}", propertyInfo.GetValue(this) as string);
                propertyInfo.GetValue(this);
            }
        }

        return output;
    }


    public ReactiveCommand<Unit, Unit> GenerateOutput { get; }

    public void GenerateOutputCommand()
    {
        DialogOwnerTemplate = ReadTemplate("DialogOwnerTemplate.txt");
        ViewModelSenderTemplate = ReadTemplate("ViewModelSenderTemplate.txt");
        NameOfDialogsViewTemplate = ReadTemplate("NameOfDialogsViewTemplate.txt");
        NameOfDialogsViewModelTemplate = ReadTemplate("NameOfDialogsViewModelTemplate.txt");
    }



}
