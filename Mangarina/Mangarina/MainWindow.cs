using System;
using Gtk;
using System.IO;
using System.Diagnostics;
using WebKit2;
using System.Threading;
using System.Linq;

public partial class MainWindow : Gtk.Window
{
    //Yes, this truckload of variables is "mangatory"
    WebView webView = new WebView();
    string initial_url = "inicio.html";
    string page_url = "page.html";
    string loading_url = "loading.html";
    string tutorial_url = "tutorial.html";
    string[] filesInFolder;
    string folder;
    string currentFile;
    string runDir;
    string tmpDir;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {

        Build();

        runDir = Directory.GetCurrentDirectory() + "/";

        tutorial_url = "file://" + runDir + "html/tutorial.html";
        page_url = "file://" + runDir + "page.html";
        initial_url = "file://" + runDir + "html/index.html";
        loading_url = "file://" + runDir + "html/loading.html";
        tmpDir = runDir + "tmp/";

        WebKit2.Settings settings = new WebKit2.Settings();
        //Let's add some random crap
        settings.UserAgent = "€ggsßbox/-2.0 (わOS; Pøw€rP© ©iŧröniuß 3.8; rv:24.0) W€ßKiŧGŧĸ/20160405 Mængærınæ/1.0";
        //Without UTF-8, the accents look like ßħiŧ
        settings.DefaultCharset = "UTF-8";
        //Let it autoload images
        settings.AutoLoadImages = true;
        //Let it run JavaScript
        settings.EnableJavascript = true;
        //Better user experience
        settings.EnableSmoothScrolling = true;
        //All the settings into the settings of the webview
        webView.Settings = settings;
        //Load the page
        webView.LoadUri(initial_url);
        //Put the WebView into the HBox1
        hbox1.PackStart(webView, true, true, 3);

        //Show it (I've spent literally ONE FUCKING HOUR trying to figure out
        //Why the WebView didn't show up
        webView.Show();
    }

    public int Locate(string[] folder, string file)
    {
        for (int i = 0; i < folder.Length; i++)
        {
            //Debug
            //Console.WriteLine("Entrada " + i + ": " + folder[i] + "\n");
            if (file == folder[i])
            {
                //Debug
                //Console.WriteLine("\nMe encuentro en la entrada " + i);
                return i;
            }
        }
        return -1;
    }

    public void Decompress(string fileToDecompress)
    {
        //Ah yes, quality integration with C#
        string command = "x \"" + fileToDecompress + "\" -otmp/";
        Process.Start("7z", command);
    }

    public void LoadChapter(int pos)
    {
        string[] filesInTMP = Directory.GetFiles(tmpDir);
        foreach (string file in filesInTMP) //This loopy thing will show up 3 more times
        {
            File.Delete(file);
        }
        File.Delete(runDir + "page.html");
        //Ah yes, quality debugging
        //Console.WriteLine("Ruta del archivo: " + filesInFolder[pos]);
        Decompress(filesInFolder[pos]);

        Thread.Sleep(3000);
        this.Title = filesInFolder[pos];
        webView.LoadUri(loading_url);
        //File.Delete(runDir + "page.html");
        Process.Start("sh", runDir + "php.sh");
        //We sleep so the extraction and the interpretation of the file
        //End up correctly (Plz don't break)
        Thread.Sleep(100);
        //And now (finally, after 100 years) we load the webpage
        webView.LoadUri(page_url);
        Thread.Sleep(100);
        webView.Reload();

    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        string[] files = Directory.GetFiles(tmpDir);
        foreach (string file in files)//Di 2nd taim
        {
            File.Delete(file);
        }
        File.Delete(runDir + "page.html");
        Application.Quit();
        a.RetVal = true;
    }

    protected void Open(object sender, EventArgs e)
    {
        File.Delete(runDir + "page.html");
        string[] files = Directory.GetFiles(tmpDir);
        foreach (string file in files)//Di 3rd taim
        {
            File.Delete(file);
        }
        FileChooserDialog chooser = new FileChooserDialog(
        "Please select a manga to view ...",  //Ah yes "manga" (変態)
        this, //Wat's dis
        FileChooserAction.Open, //Open my foken 変態's pliz
        "Cancel", ResponseType.Cancel, //NOOOOOOOOOOOOO, my 変態!!!
        "Open", ResponseType.Accept); //Noice

        if (chooser.Run() == (int)ResponseType.Accept) //Plz ye
        {
            // Open the file for reading.
            //CAN'T FOKEN READ THIS CLUSTERFUCK
            System.IO.StreamReader file =
            System.IO.File.OpenText(chooser.Filename);

            filesInFolder = Directory.GetFiles(chooser.CurrentFolder);

            folder = chooser.CurrentFolder;

            currentFile = chooser.Filename;

            filesInFolder = filesInFolder.OrderBy(x => x).ToArray();
            // Copy the contents into the logTextView
            //textview1.Buffer.Text = file.ReadToEnd();
            //Fucc off, this is from my notepad
            this.Title = chooser.Filename;
            //Decompress file and set the first image
            //W8 wut? Set the first image??????????????
            Decompress(chooser.Filename);

            // Set the MainWindow Title to the filename.
            //this.Title = "Mangarina -- " + chooser.Filename.ToString();
            //Plz shut

            // Make the MainWindow bigger to accomodate the 変態 in the WebView
            this.Resize(480, 640);
            // Close the file so as to not leave a mess.
            //Well, this is already a mess.
            file.Close();
            webView.LoadUri(loading_url);
        } // end if
        chooser.Destroy();
        Thread.Sleep(3000); //Now we must annoy our users

        //File.Delete(runDir + "page.html");

        Process.Start("sh", runDir + "php.sh");

        //We sleepy-sleep so the extraction and the interpretation of the file
        //Ends up correctly
        //Plz don't break
        Thread.Sleep(100);
        //And now we load the webpage
        //This has made me waste so many litres of Fanta to try to cure
        //My depression
        webView.LoadUri(page_url);
    }

    protected void Quit(object sender, EventArgs e)
    {
        string[] files = Directory.GetFiles(tmpDir);
        foreach (string file in files)//Da 4th taim
        {
            File.Delete(file);
        }
        //Ah yes, debug
        //File.Delete(runDir + "page.html");
        Application.Quit();
        File.Delete(runDir + "page.html");
    }

    protected void NextChapter(object sender, EventArgs e)
    {
        //Weird shit don't wanna read
        int posicion = Locate(filesInFolder, currentFile);
        LoadChapter(posicion + 1);
        currentFile = filesInFolder[posicion + 1];
    }

    protected void PreviousChapter(object sender, EventArgs e)
    {
        //Same but baccwards
        int posicion = Locate(filesInFolder, currentFile);
        LoadChapter(posicion - 1);
        currentFile = filesInFolder[posicion - 1];
    }

    protected void Tutorial(object sender, EventArgs e)
    {
        //One tutorial for ya
        webView.LoadUri(tutorial_url);
    }

    protected void About(object sender, EventArgs e)
    {
        //Enslaved self-promotion
        AboutDialog about = new AboutDialog();
        about.Title = "About - Mangarina";
        //My code is here and I don't like it
        about.Version = "Alpha 0.1 - MAY (AND WILL) CONTAIN BUGS";
        //Fun facc: 私のお尻 means "my butt" in Japanese
        string[] authors = { "DisableGraphics", "私のお尻" };
        about.Authors = authors;
        about.Name = "Mangarina - Manga Reader";
        about.License = "GNU General Public License Version 3.0";
        about.Website = "https://github.com/DisableGraphics/Mangarina";
        about.Show();
    }
}
