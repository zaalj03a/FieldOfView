using System;
using ABB.Robotics.RobotStudio.Environment;
using ABB.Robotics.RobotStudio.Stations.Forms;
using FieldOfView.Properties;

namespace FieldOfView
{
    public class FieldofView
    {
        private const int DEFAULT_FIELD_OF_VIEW = 30;
        private const string CUSTOM_CTRL_ID = "Open.Addin.FieldOfView.FovSliderCustomControl";
        private const string POPUP_ID = "Open.Addin.FieldOfView.CommandBarPopup";

        public static void AddinMain()
        {
            // Set FoV according to saved values
            if (AddinSettings.Default.UseDefault)
            {
                SetFoV(DEFAULT_FIELD_OF_VIEW);
            }
            else
            {
                SetFoV(AddinSettings.Default.FoV);
            }

            // Get the context ribbon group for graphics, which is where the FoV slider will be placed
            RibbonContextTabGroup graphicsGroup = RibbonContextTabGroup.FromSelectionType("Graphics");

            // Create the FoV slider control with the saved parameters 
            FieldOfViewSlider fovSlider = new FieldOfViewSlider(AddinSettings.Default.FoV, AddinSettings.Default.UseDefault, DEFAULT_FIELD_OF_VIEW);

            // Set up listeners
            fovSlider.VisibleChanged += FovSlider_VisibleChanged;
            fovSlider.FoVChanged += FoVSlider_FoVChanged;
            fovSlider.ParentChanged += FovSlider_ParentChanged;
            GraphicControl.ActiveGraphicControlChanged += GraphicControl_ActiveGraphicControlChanged;

            // Add the FoV slider control to a CommandBarCustomControl
            CommandBarCustomControl customCtrl = new CommandBarCustomControl(CUSTOM_CTRL_ID, "", fovSlider);
            
            // Add the custom control to a CommandBarPopup
            CommandBarPopup cmdBarPopup = new CommandBarPopup(POPUP_ID, "Field Of View", customCtrl)
            {
                Enabled = CommandBarPopupEnableMode.Enabled,
                Image = Resources.FieldOfViewIcon,
                HelpText = "Adjust the angular field of view"
            };
            
            // Finally add the CommandBarPopup to the ViewSettings group
            graphicsGroup.RibbonTabs["GraphicsView"].Groups["ViewSettings"].Controls.Add(new CommandBarSeparator());
            graphicsGroup.RibbonTabs["GraphicsView"].Groups["ViewSettings"].Controls.Add(cmdBarPopup);
        }

        private static void FovSlider_ParentChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                FieldOfViewSlider fovSlider = sender as FieldOfViewSlider;

                // If fovSlider is visible when ParentChanged event is fired then the parent control (CommandBarPopup) is about to close
                // If fovSlider is not visible then the parent control is about to open. Using this method it is possible to reliably determine
                // if the control is closing/opening now matter how the control is closed.
                if (fovSlider.Visible == true)
                {
                    // Save the settings persistently
                    SaveFoVSettings(fovSlider.GetFoV(), fovSlider.IsDefaultSelect());
                    // Re-enable screentips
                    UIEnvironment.ShowScreenTips = true;
                }
                else
                {
                    // Disable screentips to prevent an empty screentip from appearing on the fovSlider when hovered over
                    UIEnvironment.ShowScreenTips = false;
                } 
            }
        }

        private static void GraphicControl_ActiveGraphicControlChanged(object sender, EventArgs e)
        {
            // Enforce the chosen FoV value on all views
            if (AddinSettings.Default.UseDefault)
            {
                SetFoV(DEFAULT_FIELD_OF_VIEW);
            }
            else
            {
                SetFoV(AddinSettings.Default.FoV);
            }
        }

        private static void FovSlider_VisibleChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                FieldOfViewSlider fovSlider = sender as FieldOfViewSlider;

                if (fovSlider.ParentForm != null)
                {
                    // Adjust the CommandBarPopup to fit the FoV slider control
                    fovSlider.ParentForm.Size = fovSlider.Size;
                }
            }
        }

        private static void FoVSlider_FoVChanged(object sender, FieldOfViewSlider.FoVEventArgs e)
        {
            if (e != null)
            {
                // Enforce chosen FoV value on all views 
                SetFoV(e.FoV);
            }
        }

        private static void SaveFoVSettings(int FoV, bool defaultSelected)
        {
            AddinSettings.Default.FoV = FoV;
            AddinSettings.Default.UseDefault = defaultSelected;
            AddinSettings.Default.Save();
        }

        private static void SetFoV(int FoV)
        {
            GraphicControl[] controls = GraphicControl.GetAllGraphicControls();

            if ((controls?.Length ?? 0) > 0)
            {
                for (int i = 0; i < controls.Length; i++)
                {
                    controls[i].FieldOfView = FoV;
                }
            }
        }



    }
}