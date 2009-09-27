// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



public partial class PreferencesWin {
    
    private Gtk.VBox prefVbox;
    
    private Gtk.Notebook prefNotebook;
    
    private Gtk.Label generalPage;
    
    private Gtk.Label networkPage;
    
    private Gtk.HBox buttonsBox;
    
    private Gtk.Fixed fixedArea;
    
    private Gtk.Button cancelButton;
    
    private Gtk.Button applyButton;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget PreferencesWin
        this.Name = "PreferencesWin";
        this.Title = Mono.Unix.Catalog.GetString("Preferences");
        this.Icon = Stetic.IconLoader.LoadIcon(this, "gtk-preferences", Gtk.IconSize.Menu, 16);
        this.WindowPosition = ((Gtk.WindowPosition)(1));
        this.Gravity = ((Gdk.Gravity)(5));
        // Container child PreferencesWin.Gtk.Container+ContainerChild
        this.prefVbox = new Gtk.VBox();
        this.prefVbox.Name = "prefVbox";
        this.prefVbox.Spacing = 6;
        // Container child prefVbox.Gtk.Box+BoxChild
        this.prefNotebook = new Gtk.Notebook();
        this.prefNotebook.CanFocus = true;
        this.prefNotebook.Name = "prefNotebook";
        this.prefNotebook.CurrentPage = 0;
        // Notebook tab
        Gtk.Label w1 = new Gtk.Label();
        w1.Visible = true;
        this.prefNotebook.Add(w1);
        this.generalPage = new Gtk.Label();
        this.generalPage.Name = "generalPage";
        this.generalPage.LabelProp = "General";
        this.prefNotebook.SetTabLabel(w1, this.generalPage);
        this.generalPage.ShowAll();
        // Notebook tab
        Gtk.Label w2 = new Gtk.Label();
        w2.Visible = true;
        this.prefNotebook.Add(w2);
        this.networkPage = new Gtk.Label();
        this.networkPage.Name = "networkPage";
        this.networkPage.LabelProp = Mono.Unix.Catalog.GetString("Network");
        this.prefNotebook.SetTabLabel(w2, this.networkPage);
        this.networkPage.ShowAll();
        this.prefVbox.Add(this.prefNotebook);
        Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.prefVbox[this.prefNotebook]));
        w3.Position = 0;
        // Container child prefVbox.Gtk.Box+BoxChild
        this.buttonsBox = new Gtk.HBox();
        this.buttonsBox.Name = "buttonsBox";
        this.buttonsBox.Spacing = 6;
        // Container child buttonsBox.Gtk.Box+BoxChild
        this.fixedArea = new Gtk.Fixed();
        this.fixedArea.Name = "fixedArea";
        this.fixedArea.HasWindow = false;
        this.buttonsBox.Add(this.fixedArea);
        Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.buttonsBox[this.fixedArea]));
        w4.Position = 0;
        // Container child buttonsBox.Gtk.Box+BoxChild
        this.cancelButton = new Gtk.Button();
        this.cancelButton.CanFocus = true;
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.UseStock = true;
        this.cancelButton.UseUnderline = true;
        this.cancelButton.Label = "gtk-cancel";
        this.buttonsBox.Add(this.cancelButton);
        Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.buttonsBox[this.cancelButton]));
        w5.Position = 1;
        w5.Expand = false;
        w5.Fill = false;
        // Container child buttonsBox.Gtk.Box+BoxChild
        this.applyButton = new Gtk.Button();
        this.applyButton.CanFocus = true;
        this.applyButton.Name = "applyButton";
        this.applyButton.UseStock = true;
        this.applyButton.UseUnderline = true;
        this.applyButton.Label = "gtk-apply";
        this.buttonsBox.Add(this.applyButton);
        Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.buttonsBox[this.applyButton]));
        w6.PackType = ((Gtk.PackType)(1));
        w6.Position = 2;
        w6.Expand = false;
        w6.Fill = false;
        this.prefVbox.Add(this.buttonsBox);
        Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.prefVbox[this.buttonsBox]));
        w7.PackType = ((Gtk.PackType)(1));
        w7.Position = 1;
        w7.Expand = false;
        w7.Fill = false;
        this.Add(this.prefVbox);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 338;
        this.DefaultHeight = 264;
        this.Show();
        this.cancelButton.Clicked += new System.EventHandler(this.OnCancelClicked);
        this.applyButton.Clicked += new System.EventHandler(this.OnApplyClicked);
    }
}