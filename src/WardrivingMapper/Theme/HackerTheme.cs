using MudBlazor;

namespace WardrivingMapper.Theme;

public static class HackerTheme
{
    public static MudTheme Theme { get; } = new MudTheme
    {
        PaletteLight = new PaletteLight
        {

            Primary = "#00FF41",
            PrimaryContrastText = "#000000",
            Secondary = "#00E5FF",
            SecondaryContrastText = "#000000",
            Tertiary = "#B6FF00",
            TertiaryContrastText = "#000000",

            Background = "#080B0A",
            BackgroundGray = "#0D1210",
            Surface = "#101614",

            AppbarBackground = "#070A09",
            AppbarText = "#00FF41",

            DrawerBackground = "#090D0B",
            DrawerText = "#8FA89A",
            DrawerIcon = "#00FF41",

            TextPrimary = "#D7FFE3",
            TextSecondary = "#7F9B89",

            ActionDefault = "#587060",
            ActionDisabled = "#26352C",
            ActionDisabledBackground = "#111713",

            Divider = "#1B3025",
            DividerLight = "#14221B",

            LinesDefault = "#1B3025",
            LinesInputs = "#294234",

            TableLines = "#17271F",
            TableStriped = "#0D1411",
            TableHover = "#13231A",

            Dark = "#050706",
            GrayDefault = "#34453B",
            GrayLight = "#718578",
            GrayLighter = "#B0C0B5",
            GrayDark = "#17221C",
            GrayDarker = "#101612",
            Success = "#00FF41",
            Info = "#00E5FF",
            Warning = "#FFB000",
            Error = "#FF1744",
        },

        PaletteDark = new PaletteDark
        {
            Primary = "#00FF41",
            PrimaryContrastText = "#001A07",

            Secondary = "#00E5FF",
            SecondaryContrastText = "#00151A",

            Tertiary = "#B6FF00",
            TertiaryContrastText = "#081000",

            Background = "#050706",
            BackgroundGray = "#080D0A",
            Surface = "#0C1210",

            DrawerBackground = "#070B09",
            DrawerText = "#8FA89A",
            DrawerIcon = "#00FF41",

            AppbarBackground = "#040605",
            AppbarText = "#00FF41",

            TextPrimary = "#D7FFE3",
            TextSecondary = "#7F9B89",

            ActionDefault = "#6B8274",
            ActionDisabled = "#304037",
            ActionDisabledBackground = "#0D120F",

            Divider = "#193024",
            DividerLight = "#122019",

            LinesDefault = "#193024",
            LinesInputs = "#294234",

            TableLines = "#17271F",
            TableStriped = "#09100C",
            TableHover = "#102119",

            Dark = "#020302",
            GrayDefault = "#34453B",
            GrayLight = "#718578",
            GrayLighter = "#B0C0B5",
            GrayDark = "#17221C",
            GrayDarker = "#101612",

            Success = "#00FF41",
            Info = "#00E5FF",
            Warning = "#FFB000",
            Error = "#FF1744",

            OverlayDark = "rgba(0, 0, 0, 0.75)"
        },

        Typography = new Typography
        {
            Default = new DefaultTypography
            {
                FontFamily =
                [
                    "Inter",
                    "Roboto",
                    "sans-serif"
                ],
                FontSize = "0.875rem",
                FontWeight = "400",
                LineHeight = "1.43",
                LetterSpacing = "0.01071em"
            },

            H1 = new H1Typography
            {
                FontFamily =
                [
                    "JetBrains Mono",
                    "monospace"
                ],
                FontWeight = "700",
                FontSize = "2.5rem",
                LineHeight = "1.2"
            },

            H2 = new H2Typography
            {
                FontFamily =
                [
                    "JetBrains Mono",
                    "monospace"
                ],
                FontWeight = "700",
                FontSize = "2rem",
                LineHeight = "1.25"
            },

            H3 = new H3Typography
            {
                FontFamily =
                [
                    "JetBrains Mono",
                    "monospace"
                ],
                FontWeight = "600"
            },

            H4 = new H4Typography
            {
                FontFamily =
                [
                    "JetBrains Mono",
                    "monospace"
                ],
                FontWeight = "600"
            },

            H5 = new H5Typography
            {
                FontFamily =
                [
                    "JetBrains Mono",
                    "monospace"
                ],
                FontWeight = "600"
            },

            H6 = new H6Typography
            {
                FontFamily =
                [
                    "JetBrains Mono",
                    "monospace"
                ],
                FontWeight = "600"
            },

            Button = new ButtonTypography
            {
                FontFamily =
                [
                    "JetBrains Mono",
                    "monospace"
                ],
                FontWeight = "600",
                TextTransform = "uppercase"
            },

            Caption = new CaptionTypography
            {
                FontFamily =
                [
                    "JetBrains Mono",
                    "monospace"
                ]
            }
        },

        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "3px",
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "300px",
            AppbarHeight = "56px"
        }
    };

}   
