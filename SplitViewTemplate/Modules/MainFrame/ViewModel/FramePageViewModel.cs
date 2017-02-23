﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SplitViewTemplate.Modules.MainFrame.Model;
using SplitViewTemplate.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace SplitViewTemplate.Modules.MainFrame.ViewModel
{
    public class FramePageViewModel : ViewModelBase
    {
        private const string PLAYING_ICON = "M18.7500019073486,15L20,15 20,18.75 18.7500019073486,18.75 18.7500019073486,15z M14.3750009536743,15L15.6250009536743,15 15.6250009536743,18.75 14.3750009536743,18.75 14.3750009536743,15z M9.37500095367432,15L10.6250009536743,15 10.6250009536743,18.75 9.37500095367432,18.75 9.37500095367432,15z M4.37500047683716,15L5.62500047683716,15 5.62500047683716,18.75 4.37500047683716,18.75 4.37500047683716,15z M2.98023223876953E-07,15L1.25000023841858,15 1.25000023841858,18.75 2.98023223876953E-07,18.75 2.98023223876953E-07,15z M14.3750009536743,10L15.6250009536743,10 15.6250009536743,13.75 14.3750009536743,13.75 14.3750009536743,10z M9.37500095367432,10L10.6250009536743,10 10.6250009536743,13.75 9.37500095367432,13.75 9.37500095367432,10z M4.37500047683716,10L5.62500047683716,10 5.62500047683716,13.75 4.37500047683716,13.75 4.37500047683716,10z M2.98023223876953E-07,10L1.25000023841858,10 1.25000023841858,13.75 2.98023223876953E-07,13.75 2.98023223876953E-07,10z M14.3750009536743,5L15.6250009536743,5 15.6250009536743,8.75 14.3750009536743,8.75 14.3750009536743,5z M9.37500095367432,5L10.6250009536743,5 10.6250009536743,8.75 9.37500095367432,8.75 9.37500095367432,5z M2.98023223876953E-07,5L1.25000023841858,5 1.25000023841858,8.75 2.98023223876953E-07,8.75 2.98023223876953E-07,5z M0,2.38418579101563E-06L1.25,2.38418579101563E-06 1.25,3.75000214576721 0,3.75000214576721 0,2.38418579101563E-06z M9.37500095367432,0L10.6250009536743,0 10.6250009536743,3.75 9.37500095367432,3.75 9.37500095367432,0z";
        private const string ALBUM_ICON = "M4.84249496459961,11.0799970626831L1.1187561750412,11.6181364059448 1.40937447547913,13.1507358551025 1.90858995914459,14.2757034301758 2.38085460662842,14.9686031341553 2.59062027931213,15.2049999237061 5.65500736236572,13.1406202316284 5.40446043014526,12.8285112380981 5.01562547683716,12.2037487030029 4.84913730621338,11.4635171890259 4.84249496459961,11.0799970626831z M8.49812316894531,9.65938472747803L9.30953025817871,9.99563121795654 9.64562225341797,10.808123588562 9.30953025817871,11.620002746582 8.49812316894531,11.9556226730347 7.68578481674194,11.620002746582 7.35062217712402,10.808123588562 7.68578481674194,9.99563121795654 8.49812316894531,9.65938472747803z M8.48063182830811,7.87124538421631L7.3410177230835,8.10119724273682 6.41093778610229,8.72835731506348 5.78414106369019,9.65868282318115 5.55437564849854,10.7981290817261 5.78414106369019,11.936749458313 6.41093778610229,12.8664836883545 7.3410177230835,13.4932909011841 8.48063182830811,13.7231245040894 9.61879348754883,13.4932909011841 10.5481328964233,12.8664836883545 11.1746616363525,11.936749458313 11.404390335083,10.7981290817261 11.1746616363525,9.65868282318115 10.5481328964233,8.72835731506348 9.61879348754883,8.10119724273682 8.48063182830811,7.87124538421631z M8.47124862670898,2.11688041687012L11.0998458862305,2.53594255447388 13.3918876647949,3.69937872886658 13.3918876647949,3.80437803268433 11.641263961792,4.54062366485596 10.8603000640869,5.40381956100464 10.4453201293945,6.38601922988892 10.4222183227539,7.36833715438843 10.8168888092041,8.2318868637085 11.5734729766846,8.80545520782471 12.536958694458,8.99640941619873 13.5858774185181,8.80510139465332 14.5987644195557,8.2318868637085 15.3888311386108,7.35078382492065 15.7987546920776,6.34875154495239 16.6429042816162,8.35640621185303 16.943775177002,10.5881299972534 16.2780685424805,13.8857049942017 14.4625148773193,16.578592300415 11.769458770752,18.3942165374756 8.47124862670898,19.0599975585938 5.17403411865234,18.3942165374756 2.48132920265198,16.578592300415 0.665771901607513,13.8857049942017 0,10.5881299972534 0.665771901607513,7.29038619995117 2.48132920265198,4.59773969650269 5.17403411865234,2.78247594833374 8.47124862670898,2.11688041687012z M19.7418956756592,0L20,0.301876038312912 20,1.67437553405762 20,1.86625480651855 20,5.66187763214111 19.9893932342529,5.72375249862671 19.8326759338379,6.50296831130981 19.2193965911865,7.17061853408813 18.1036109924316,7.47031831741333 17.2400245666504,6.98625516891479 17.1360359191895,6.0021915435791 17.8519020080566,5.09500455856323 18.674388885498,4.79750061035156 19.4331340789795,4.9293794631958 19.4331340789795,2.1975040435791 14.5900287628174,2.64500594139099 14.5900287628174,5.85312747955322 14.5192375183105,6.72593975067139 13.8606185913086,7.49000406265259 12.7439136505127,7.78914546966553 11.8812665939331,7.3050103187561 11.7765769958496,6.32133054733276 12.4912557601929,5.41313076019287 13.2832117080688,5.12094020843506 14.0231246948242,5.22812747955322 14.0231246948242,2.37125396728516 14.0231246948242,2.36750602722168 14.0231246948242,0.806875228881836 14.2812671661377,0.504379272460938 19.7418956756592,0z";
        private const string ALL_MUSIC_ICON = "M6.76357650756836,14.8156337738037L5.36724472045898,15.0714912414551 3.78481912612915,15.7806282043457 2.02903389930725,17.116870880127 1.27731323242188,18.2543640136719 1.27606332302094,18.5493621826172 1.9879401922226,18.7499847412109 3.38388109207153,18.4944400787354 4.96544742584229,17.7856159210205 6.72177982330322,16.4490604400635 7.47357797622681,15.3112554550171 7.47482776641846,15.0162572860718 6.76357650756836,14.8156337738037z M18.013557434082,14.8156261444092L16.6172275543213,15.0714960098267 15.0348014831543,15.7806634902954 13.2790174484253,17.1168880462646 12.5272951126099,18.2543277740479 12.5260457992554,18.5493545532227 13.2379236221313,18.7500057220459 14.6338653564453,18.494441986084 16.2154293060303,17.7855815887451 17.9717617034912,16.4490432739258 18.723560333252,15.3112297058105 18.7248096466064,15.0162792205811 18.013557434082,14.8156261444092z M0,10.7375078201294L6.24999046325684,10.7375078201294 6.24999046325684,11.9875059127808 0,11.9875059127808 0,10.7375078201294z M0,6.98751211166382L6.24999046325684,6.98751211166382 6.24999046325684,8.23751068115234 0,8.23751068115234 0,6.98751211166382z M0,3.23751831054688L6.24999046325684,3.23751831054688 6.24999046325684,4.48751592636108 0,4.48751592636108 0,3.23751831054688z M19.9999694824219,0L19.9999694824219,15.1131601333618 19.9993705749512,15.1131601333618 19.9999732971191,15.1362953186035 19.9310646057129,15.6350202560425 18.8848915100098,17.3048362731934 16.8360595703125,18.870626449585 14.9530839920044,19.7045917510986 13.2379236221313,20 12.0166711807251,19.729663848877 11.4460458755493,19.1780891418457 11.2701835632324,18.6809234619141 11.3197927474976,17.9306144714355 12.3656558990479,16.2608451843262 14.4141778945923,14.6956176757813 16.2977752685547,13.8613481521606 18.013557434082,13.5656337738037 18.7204151153564,13.6413049697876 18.7499713897705,13.6488056182861 18.7499713897705,1.47625350952148 8.74998760223389,3.14250731468201 8.74998760223389,15.1131601333618 8.74938774108887,15.1131601333618 8.74998950958252,15.1363039016724 8.68108081817627,15.6350030899048 7.63490629196167,17.304838180542 5.58607387542725,18.8706111907959 3.70310044288635,19.70458984375 1.9879401922226,19.999979019165 0.766687273979187,19.7296676635742 0.196060851216316,19.178108215332 0.0202010292559862,18.6809234619141 0.0698100551962852,17.9306163787842 1.11567234992981,16.2608585357666 3.16419267654419,14.6956338882446 5.04779100418091,13.8613414764404 6.76357650756836,13.5656404495239 7.47043371200562,13.6413145065308 7.49998950958252,13.6488161087036 7.49998950958252,2.0837550163269 19.9999694824219,0z";
        private const string ARTIST_ICON = "M7.2734581,4.4140009C7.3734943,4.4140009 7.4734689,4.4140009 7.4734689,4.5139918 7.5744816,4.6139979 7.5744816,4.8150019 7.4734689,5.0159907L2.5585288,9.8309931 6.3704501,13.64299 10.182432,9.8309931C10.683466,9.3289942,14.194426,9.4290003,14.5964,9.4290003L16.000381,20.162994 17.304387,9.4290003C17.605411,9.4290003,21.216346,9.4290003,21.718356,9.8309931L25.530337,13.64299 29.342321,9.8309931C29.944307,9.2290034 30.94729,9.2290034 31.549274,9.8309931 32.150281,10.432998 32.150281,11.436004 31.549274,12.037994L26.633296,16.953002C26.332334,17.253997 25.931337,17.354003 25.530337,17.354003 25.128303,17.354003 24.727306,17.253997 24.426343,16.953002L21.317357,13.843002 21.317357,22.871C21.317357,25.078,19.511401,25.579999,17.304387,25.579999L14.5964,25.579999C12.389447,25.579999,10.58343,25.078,10.58343,22.871L10.58343,13.843002 7.4734689,16.953002C7.1724459,17.253997 6.7714478,17.354003 6.3704501,17.354003 5.969452,17.354003 5.5674778,17.253997 5.2664543,16.953002L0.45148889,12.037994C-0.1504963,11.436004 -0.1504963,10.432998 0.45148889,9.8309931 0.75251193,9.5299983 1.1544864,9.4290003 1.5554842,9.4290003 1.6555202,9.4290003 1.8565074,9.4290003 1.9564822,9.5299983L2.0565184,9.5299983 7.0724713,4.5139918C7.0724713,4.4140009,7.1724459,4.4140009,7.2734581,4.4140009z M16.000381,0C18.207397,-1.4963598E-07 20.013351,1.8059995 20.013351,4.013 20.013351,6.2189936 18.207397,8.0249934 16.000381,8.0249934 13.793429,8.0249934 11.987412,6.2189936 11.987412,4.013 11.987412,1.8059995 13.793429,-1.4963598E-07 16.000381,0z";
        private const string DETECTION_ICON = "M4.90249109268188,16.2518787384033L4.90249109268188,18.7506198883057 14.8981266021729,18.7506198883057 14.8981266021729,16.2518787384033 4.90249109268188,16.2518787384033z M10.4212579727173,5.89437007904053L9.68524074554443,6.1995267868042 9.3800048828125,6.93499708175659 9.68524074554443,7.67101430892944 10.4212579727173,7.97624921798706 11.1572751998901,7.67101430892944 11.4625101089478,6.93499708175659 11.1572751998901,6.1995267868042 10.4212579727173,5.89437007904053z M10.4212579727173,4.64499235153198L11.312050819397,4.82526636123657 12.0402450561523,5.31655597686768 12.5316038131714,6.04456567764282 12.7118873596191,6.93499708175659 12.5316038131714,7.8261513710022 12.0402450561523,8.55453205108643 11.312050819397,9.04595947265625 10.4212579727173,9.22625255584717 9.5304651260376,9.04595947265625 8.80226993560791,8.55453205108643 8.31091117858887,7.8261513710022 8.13062763214111,6.93499708175659 8.31091117858887,6.04456567764282 8.80226993560791,5.31655597686768 9.5304651260376,4.82526636123657 10.4212579727173,4.64499235153198z M1.28500068187714,3.66374468803406L0.818047285079956,3.85710477828979 0.624375224113464,4.32374620437622 1.08872866630554,4.95463132858276 1.10910713672638,4.95988130569458 1.42234587669373,4.96975803375244 1.48098301887512,4.95463132858276 1.94500088691711,4.32374620437622 1.75140702724457,3.85710477828979 1.28500068187714,3.66374468803406z M1.28500068187714,3.03874349594116L2.19304776191711,3.41569757461548 2.57000112533569,4.32374620437622 2.35013151168823,5.04199028015137 1.78452241420746,5.50816345214844 1.77002120018005,5.51348543167114 1.75859892368317,5.88393259048462 1.83959984779358,9.18199634552002 2.15882849693298,10.7834968566895 2.79429960250854,12.2631235122681 3.87951993942261,13.9129228591919 4.91495609283447,14.9973554611206 4.92363405227661,15.002498626709 16.1474990844727,15.002498626709 16.1474990844727,20 3.65312027931213,20 3.65312027931213,15.5557022094727 3.61458730697632,15.5182695388794 2.40102195739746,13.9984378814697 1.96756494045258,13.3217315673828 1.71301472187042,12.8881244659424 0.945656061172485,11.080828666687 0.58290034532547,9.16132640838623 0.522976696491241,5.41812324523926 0.524871826171875,5.35796070098877 0.468009531497955,5.31538581848145 0,4.32374620437622 0.376718997955322,3.41569757461548 1.28500068187714,3.03874349594116z M10.3168830871582,1.24937450885773L8.02479362487793,1.71325170993805 6.15094709396362,2.97757863998413 4.886474609375,4.85139751434326 4.42251014709473,7.14375162124634 4.886474609375,9.4357442855835 6.15094709396362,11.3093776702881 8.02479362487793,12.5736360549927 10.3168830871582,13.0375032424927 12.6089725494385,12.5736360549927 14.4828195571899,11.3093776702881 15.7472915649414,9.4357442855835 16.2112560272217,7.14375162124634 15.7472915649414,4.85139751434326 14.4828195571899,2.97757863998413 12.6089725494385,1.71325170993805 10.3168830871582,1.24937450885773z M10.3168830871582,0L13.0950164794922,0.562236368656158 15.3660202026367,2.09460973739624 16.8983917236328,4.36561584472656 17.4606285095215,7.14375162124634 16.8983917236328,9.92162322998047 15.3660202026367,12.1926593780518 13.0950164794922,13.7251787185669 10.3168830871582,14.2875032424927 7.53901290893555,13.7251787185669 5.26797866821289,12.1926593780518 3.73545980453491,9.92162322998047 3.17313575744629,7.14375162124634 3.73545980453491,4.36561584472656 5.26797866821289,2.09460973739624 7.53901290893555,0.562236368656158 10.3168830871582,0z";

        public ObservableCollection<NaviListModel> NaviList { get; set; }

        public RelayCommand<object> ItemClickCommand
        {
            get
            {
                return new RelayCommand<object>(obj =>
                {
                    if (SelectedItem == obj)
                    {
                        return;
                    }
                    NaviListModel item = obj as NaviListModel;
                    NavigationHelper.Navigate(item.PageType);

                });
            }
        }

        public RelayCommand MainFrameLoadedCommand
        {
            get
            {

return new RelayCommand(() =>
                {
                    Messenger.Default.Send(NaviList, "selectedIndex");
                    //To-Do: 跳转到首页
                });
            }
        }

        public RelayCommand FrameNavigatedCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (SplitViewMode == SplitViewDisplayMode.Overlay || SplitViewMode == SplitViewDisplayMode.CompactOverlay)
                    {
                        IsPaneOpen = false;
                    }
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = NavigationHelper.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
                });
            }
        }

        private Nullable<Boolean> _isPaneOpen;

        public Nullable<Boolean> IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { Set(ref _isPaneOpen, value); }
        }

        private SplitViewDisplayMode _splitViewMode;

        public SplitViewDisplayMode SplitViewMode
        {
            get { return _splitViewMode; }
            set { Set(ref _splitViewMode, value); }
        }



        private object _selectedItem;

        public object SelectedItem
        {
            get { return _selectedItem; }
            set { Set(ref _selectedItem, value); }
        }


        public FramePageViewModel()
        {
            var bounds = Window.Current.CoreWindow.Bounds;
            if (bounds.Width > 900)
            {
                SplitViewMode = SplitViewDisplayMode.CompactInline;
                IsPaneOpen = true;
            }
            else if (bounds.Width > 550)
            {
                SplitViewMode = SplitViewDisplayMode.CompactOverlay;
                IsPaneOpen = false;
            }
            else
            {
                SplitViewMode = SplitViewDisplayMode.Overlay;
                IsPaneOpen = false;
            }
            NaviList = new ObservableCollection<NaviListModel>();
            AddPages();
        }

        public void AddPages()
        {
            if (NaviList != null)
            {
                //To-Do: 添加导航列表项

            }
        }

    }
}
