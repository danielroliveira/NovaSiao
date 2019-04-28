Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
'
''' <span class="code-SummaryComment"><summary></span>
'''   Represents a Bordered label.
''' <span class="code-SummaryComment"></summary></span>
Partial Public Class BorderLabel
    Inherits Label
    Private m_borderSize As Single
    Private m_borderColor As Color

    Private point As PointF
    Private drawSize As SizeF
    Private drawPen As Pen
    Private drawPath As GraphicsPath
    Private forecolorBrush As SolidBrush

    ' Constructor
    '-----------------------------------------------------

#Region "Constructor"
    Public Sub New()
        Me.m_borderSize = 1.0F
        Me.m_borderColor = Color.White
        Me.drawPath = New GraphicsPath()
        Me.drawPen = New Pen(New SolidBrush(Me.m_borderColor), m_borderSize)
        Me.forecolorBrush = New SolidBrush(Me.ForeColor)

        Me.Invalidate()
    End Sub
#End Region

    ' Public Properties
    '-----------------------------------------------------

#Region "Public Properties"
    ''' <span class="code-SummaryComment"><summary></span>
    '''   The border's thickness
    ''' <span class="code-SummaryComment"></summary></span>
    <Browsable(True)>
    <Category("Appearance")>
    <Description("The border's thickness")>
    <DefaultValue(1.0F)>
    Public Property BorderSize() As Single
        Get
            Return Me.m_borderSize
        End Get
        Set
            Me.m_borderSize = Value
            If Value = 0 Then
                'If border size equals zero, disable the
                ' border by setting it as transparent
                Me.drawPen.Color = Color.Transparent
            Else
                Me.drawPen.Color = Me.BorderColor
                Me.drawPen.Width = Value
            End If

            Me.OnTextChanged(EventArgs.Empty)
        End Set
    End Property

    ''' <span class="code-SummaryComment"><summary></span>
    '''   The border color of this component
    ''' <span class="code-SummaryComment"></summary></span>
    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(GetType(Color), "White")>
    <Description("The border color of this component")>
    Public Property BorderColor() As Color
        Get
            Return Me.m_borderColor
        End Get
        Set
            Me.m_borderColor = Value

            If Me.BorderSize <> 0 Then
                Me.drawPen.Color = Value
            End If

            Me.Invalidate()
        End Set
    End Property
#End Region

    ' Event Handling
    '-----------------------------------------------------

#Region "Event Handling"
    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnTextAlignChanged(e As EventArgs)
        MyBase.OnTextAlignChanged(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub OnForeColorChanged(e As EventArgs)
        Me.forecolorBrush.Color = MyBase.ForeColor
        MyBase.OnForeColorChanged(e)
        Me.Invalidate()
    End Sub
#End Region

    ' Drawning Events
    '-----------------------------------------------------

#Region "Drawning"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        ' First let's check if we indeed have text to draw.
        '  if we have no text, then we have nothing to do.
        If Me.Text.Length = 0 Then
            Return
        End If

        ' Secondly, let's begin setting the smoothing mode to AntiAlias, to
        ' reduce image sharpening and compositing quality to HighQuality,
        ' to improve our drawnings and produce a better looking image.

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality

        ' Next, we measure how much space our drawning will use on the control.
        '  this is important so we can determine the correct position for our text.
        Me.drawSize = e.Graphics.MeasureString(Me.Text, Me.Font, New PointF(), StringFormat.GenericTypographic)

        ' Now, we can determine how we should align our text in the control
        '  area, both horizontally and vertically. If the control is set to auto
        '  size itself, then it should be automatically drawn to the standard position.

        If Me.AutoSize Then
            Me.point.X = Me.Padding.Left
            Me.point.Y = Me.Padding.Top
        Else
            ' Text is Left-Aligned:
            If Me.TextAlign = ContentAlignment.TopLeft OrElse Me.TextAlign = ContentAlignment.MiddleLeft OrElse Me.TextAlign = ContentAlignment.BottomLeft Then
                Me.point.X = Me.Padding.Left

                ' Text is Center-Aligned
            ElseIf Me.TextAlign = ContentAlignment.TopCenter OrElse Me.TextAlign = ContentAlignment.MiddleCenter OrElse Me.TextAlign = ContentAlignment.BottomCenter Then
                point.X = (Me.Width - Me.drawSize.Width) / 2
            Else

                ' Text is Right-Aligned
                point.X = Me.Width - (Me.Padding.Right + Me.drawSize.Width)
            End If

            ' Text is Top-Aligned
            If Me.TextAlign = ContentAlignment.TopLeft OrElse Me.TextAlign = ContentAlignment.TopCenter OrElse Me.TextAlign = ContentAlignment.TopRight Then
                point.Y = Me.Padding.Top

                ' Text is Middle-Aligned
            ElseIf Me.TextAlign = ContentAlignment.MiddleLeft OrElse Me.TextAlign = ContentAlignment.MiddleCenter OrElse Me.TextAlign = ContentAlignment.MiddleRight Then
                point.Y = (Me.Height - Me.drawSize.Height) / 2
            Else

                ' Text is Bottom-Aligned
                point.Y = Me.Height - (Me.Padding.Bottom + Me.drawSize.Height)
            End If
        End If

        ' Now we can draw our text to a graphics path.
        '  
        '   PS: this is a tricky part: AddString() expects float emSize in pixel, 
        '   but Font.Size measures it as points.
        '   So, we need to convert between points and pixels, which in
        '   turn requires detailed knowledge of the DPI of the device we are drawing on. 
        '
        '   The solution was to get the last value returned by the 
        '   Graphics.DpiY property and
        '   divide by 72, since point is 1/72 of an inch, 
        '   no matter on what device we draw.
        '
        '   The source of this solution can be seen on CodeProject's article
        '   'OSD window with animation effect' - 
        '   http://www.codeproject.com/csharp/OSDwindow.asp

        Dim fontSize As Single = e.Graphics.DpiY * Me.Font.SizeInPoints / 72

        Me.drawPath.Reset()
        Me.drawPath.AddString(Me.Text, Me.Font.FontFamily, CInt(Me.Font.Style), fontSize, point, StringFormat.GenericTypographic)

        ' And finally, using our pen, all we have to do now
        '  is draw our graphics path to the screen. Voila!
        e.Graphics.FillPath(Me.forecolorBrush, Me.drawPath)
        e.Graphics.DrawPath(Me.drawPen, Me.drawPath)
    End Sub
#End Region

    ''' <span class="code-SummaryComment"><summary></span>
    '''   Releases all resources used by this control
    ''' <span class="code-SummaryComment"></summary></span>
    ''' <span class="code-SummaryComment"><param name="disposing">True to release both managed and unmanaged resources.</span>
    ''' <span class="code-SummaryComment"></param></span>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Me.forecolorBrush IsNot Nothing Then
                Me.forecolorBrush.Dispose()
            End If

            If Me.drawPath IsNot Nothing Then
                Me.drawPath.Dispose()
            End If

            If Me.drawPen IsNot Nothing Then
                Me.drawPen.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

End Class


