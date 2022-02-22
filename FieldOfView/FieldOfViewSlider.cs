using System;
using System.Windows.Forms;

namespace FieldOfView
{
    internal partial class FieldOfViewSlider : UserControl
    {
        private int _defaultFoV;

        internal FieldOfViewSlider(int FoV, bool useDefault, int defaultFoV)
        {
            InitializeComponent();

            _defaultFoV = defaultFoV;

            // Configure controls to match parameters passed in constructor
            if (useDefault == false)
            {
                TrackBarFieldOfView.Value = FoV;
            }
            else
            {
                TrackBarFieldOfView.Value = _defaultFoV;
                TrackBarFieldOfView.Enabled = false;
            }

            CheckBoxDefault.Checked = useDefault;
            LabelFieldOfVIew.Text = TrackBarFieldOfView.Value.ToString() + "°";

            // This prevents the controls from getting focus when the form is created
            ActiveControl = null;

            // Set up listeners
            TrackBarFieldOfView.ValueChanged += TrackBarFieldOfView_ValueChanged;
            CheckBoxDefault.CheckedChanged += CheckBoxDefault_CheckedChanged;
        }

        internal int GetFoV()
        {
            return TrackBarFieldOfView.Value;
        }

        internal bool IsDefaultSelect()
        {
            return CheckBoxDefault.Checked;
        }

        private void TrackBarFieldOfView_ValueChanged(object sender, EventArgs e)
        {
            if (CheckBoxDefault.Checked)
            {
                OnFoVChanged(new FoVEventArgs(_defaultFoV, true));
            }
            else
            {
                OnFoVChanged(new FoVEventArgs(((TrackBar)sender).Value, false));
            }

            LabelFieldOfVIew.Text = TrackBarFieldOfView.Value.ToString() + "°";
        }

        private void CheckBoxDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxDefault.Checked)
            {
                TrackBarFieldOfView.Enabled = false;

                // If value will be changed then event will be fired from value changed event handler, otherwise event needs to be 
                // fired directly in this method
                if (TrackBarFieldOfView.Value != _defaultFoV)
                {
                    TrackBarFieldOfView.Value = _defaultFoV;
                }
                else
                {
                    TrackBarFieldOfView.Value = _defaultFoV;
                    OnFoVChanged(new FoVEventArgs(_defaultFoV, true));
                }
            }
            else
            {
                TrackBarFieldOfView.Enabled = true;
            }
        }

        /// <summary>
        /// Event is raised when field of view is changed or default value is selected
        /// </summary>
        internal EventHandler<FoVEventArgs> FoVChanged;

        private void OnFoVChanged(FoVEventArgs e)
        {
            if (FoVChanged != null)
            {
                EventHandler<FoVEventArgs> FoVEvent = FoVChanged;
                FoVEvent(null, e);
            }
        }

        internal class FoVEventArgs : EventArgs
        {
            internal int FoV { get; set; }
            internal bool defaultSelected { get; set; }
            internal FoVEventArgs(int changedValue, bool useDefault)
            {
                FoV = changedValue;
                defaultSelected = useDefault;
            }
        }
    }
}
