﻿namespace VisualPlus.Toolkit.Child
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    using VisualPlus.Designer;
    using VisualPlus.Localization;
    using VisualPlus.Toolkit.Components;

    #endregion

    [Designer(typeof(VisualTabPageDesigner))]
    [ToolboxItem(true)]
    public class VisualTabPage : TabPage
    {
        #region Variables

        private Image _image;
        private Color _tabHover;
        private Color _tabNormal;
        private Color _tabSelected;
        private StringAlignment _textAlignment;
        private StringAlignment _textLineAlignment;
        private Color _textSelected;

        /// <summary>Required designer variable.</summary>
        private Container components;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualTabPage" /> class.</summary>
        public VisualTabPage()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            UpdateStyles();

            StyleManager _styleManager = new StyleManager(Settings.DefaultValue.DefaultStyle);

            _textSelected = Color.FromArgb(217, 220, 227);

            _textLineAlignment = StringAlignment.Center;
            _textAlignment = StringAlignment.Center;

            BackColor = _styleManager.Theme.BackgroundSettings.Type4;
            Font = _styleManager.Theme.TextSetting.Font;

            _tabNormal = _styleManager.Theme.OtherSettings.TabPageEnabled;
            _tabSelected = _styleManager.Theme.OtherSettings.TabPageSelected;
            _tabHover = _styleManager.Theme.OtherSettings.TabPageHover;
        }

        #endregion

        #region Properties

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Image)]
        public Image Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TabHover
        {
            get
            {
                return _tabHover;
            }

            set
            {
                _tabHover = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TabNormal
        {
            get
            {
                return _tabNormal;
            }

            set
            {
                _tabNormal = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TabSelected
        {
            get
            {
                return _tabSelected;
            }

            set
            {
                _tabSelected = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.VerticalAlignment)]
        public StringAlignment TextAlignment
        {
            get
            {
                return _textAlignment;
            }

            set
            {
                _textAlignment = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Alignment)]
        public StringAlignment TextLineAlignment
        {
            get
            {
                return _textLineAlignment;
            }

            set
            {
                _textLineAlignment = value;
                Invalidate();
            }
        }

        [Category(PropertyCategory.Appearance)]
        [Description(PropertyDescription.Color)]
        public Color TextSelected
        {
            get
            {
                return _textSelected;
            }

            set
            {
                _textSelected = value;
                Invalidate();
            }
        }

        #endregion

        #region Events

        /// <summary>Updates the properties after an Invalidate.</summary>
        public void UpdateProperties()
        {
            try
            {
                Invalidate();
            }
            catch (Exception e)
            {
                throw new Exception(e.StackTrace);
            }
        }

        protected override ControlCollection CreateControlsInstance()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            DoubleBuffered = true;

            return base.CreateControlsInstance();
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            ForeColor = Color.FromArgb(174, 181, 187);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics _graphics = e.Graphics;
            _graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

            if (_image != null)
            {
                _graphics.DrawImage(_image, new Rectangle(new Point(0, 0), Size));
            }
        }

        /// <summary>Required method for Designer support - do not modify the contents of this method with the code editor.</summary>
        private void InitializeComponent()
        {
            components = new Container();
            Disposed += VisualTabPage_Disposed;
        }

        private void VisualTabPage_Disposed(object sender, EventArgs e)
        {
        }

        #endregion
    }
}