using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class home : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public home( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public home( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Studiosgrid") == 0 )
            {
               nRC_GXsfl_124 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_124"), "."));
               nGXsfl_124_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_124_idx"), "."));
               sGXsfl_124_idx = GetPar( "sGXsfl_124_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrStudiosgrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Studiosgrid") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrStudiosgrid_refresh( ) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Customersgrid") == 0 )
            {
               nRC_GXsfl_149 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_149"), "."));
               nGXsfl_149_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_149_idx"), "."));
               sGXsfl_149_idx = GetPar( "sGXsfl_149_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrCustomersgrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Customersgrid") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrCustomersgrid_refresh( ) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fstestimonials") == 0 )
            {
               nRC_GXsfl_163 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_163"), "."));
               nGXsfl_163_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_163_idx"), "."));
               sGXsfl_163_idx = GetPar( "sGXsfl_163_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrFstestimonials_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fstestimonials") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrFstestimonials_refresh( ) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA072( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START072( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2155220), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2155220), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2155220), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20219151905280", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("GXMediaPlayer/lib/video.min.js", "", false, true);
         context.AddJavascriptSource("GXMediaPlayer/GXMediaPlayerRender.js", "", false, true);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.home.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtlandingpurusstudiosample", AV12SDTLandingPurusStudioSample);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtlandingpurusstudiosample", AV12SDTLandingPurusStudioSample);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdthometestimonials", AV16SDTHomeTestimonials);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdthometestimonials", AV16SDTHomeTestimonials);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdthomelandingsamplelogos", AV18SDTHomeLandingSampleLogos);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdthomelandingsamplelogos", AV18SDTHomeLandingSampleLogos);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_124", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_124), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_149", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_149), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_163", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_163), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "COMPANYVIDEO_Width", StringUtil.RTrim( Companyvideo_Width));
         GxWebStd.gx_hidden_field( context, "COMPANYVIDEO_Height", StringUtil.RTrim( Companyvideo_Height));
         GxWebStd.gx_hidden_field( context, "COMPANYVIDEO_Source", StringUtil.RTrim( Companyvideo_Source));
         GxWebStd.gx_hidden_field( context, "COMPANYVIDEO_Autoplay", StringUtil.RTrim( Companyvideo_Autoplay));
         GxWebStd.gx_hidden_field( context, "STUDIOSGRID_Class", StringUtil.RTrim( subStudiosgrid_Class));
         GxWebStd.gx_hidden_field( context, "STUDIOSGRID_Flexwrap", StringUtil.RTrim( subStudiosgrid_Flexwrap));
         GxWebStd.gx_hidden_field( context, "STUDIOSGRID_Justifycontent", StringUtil.RTrim( subStudiosgrid_Justifycontent));
         GxWebStd.gx_hidden_field( context, "STUDIOSGRID_Aligncontent", StringUtil.RTrim( subStudiosgrid_Aligncontent));
         GxWebStd.gx_hidden_field( context, "CUSTOMERSGRID_Class", StringUtil.RTrim( subCustomersgrid_Class));
         GxWebStd.gx_hidden_field( context, "CUSTOMERSGRID_Showpagecontroller", StringUtil.RTrim( subCustomersgrid_Showpagecontroller));
         GxWebStd.gx_hidden_field( context, "CUSTOMERSGRID_Infinite", StringUtil.RTrim( subCustomersgrid_Infinite));
         GxWebStd.gx_hidden_field( context, "CUSTOMERSGRID_Autoplay", StringUtil.RTrim( subCustomersgrid_Autoplay));
         GxWebStd.gx_hidden_field( context, "FSTESTIMONIALS_Class", StringUtil.RTrim( subFstestimonials_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE072( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT072( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwpbaseobjects.home.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Home" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inicio" ;
      }

      protected void WB070( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionSloganHeaderLandingPurus", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSlogansection_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSlogantitle_Internalname, "Somos aliados estratégicos", "", "", lblSlogantitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSloganTitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSlogansubtitle_Internalname, "Brindamos un marco metodologico y herramientas de Gestion para mejorar sustancialmente los resultados", "", "", lblSlogansubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSloganSubtitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMainnumberssection_Internalname, divMainnumberssection_Visible, 0, "px", 0, "px", "TableContentLandingPurus", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop80", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMainnumberstitle_Internalname, "¿Quienes Somos?", "", "", lblMainnumberstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWithUnderline", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMainnumberssubtitle_Internalname, "Somos Partners de Optaris, Empresa Lider en Latinoamerica de Low Code - No Code y RPA - Robotic Process Automation", "", "", lblMainnumberssubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "6d684090-2eee-49ab-95a3-82ac72d0a9e0", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgMainnumbers_icon1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblQw_Internalname, "Finanzas y Planificacion Estrategica", "", "", lblQw_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 CellPaddingTop50", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable7_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "458a60e9-8cd3-40dc-a78d-9fd963b05e17", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgMainnumbers_icon2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblQwasd_Internalname, "Gestion de Proyectos y Operaciones", "", "", lblQwasd_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable8_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "cffcd64c-205a-4f65-b8e1-72fd2d713bc4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgMainnumbers_icon3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblQwfd_Internalname, "Tecnologia de la Informacion", "", "", lblQwfd_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock AttributeWeightBold", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divVideosection_Internalname, divVideosection_Visible, 0, "px", 0, "px", "LandingPurusVideoCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCompanyvideo.SetProperty("Width", Companyvideo_Width);
            ucCompanyvideo.SetProperty("Height", Companyvideo_Height);
            ucCompanyvideo.SetProperty("Source", Companyvideo_Source);
            ucCompanyvideo.SetProperty("Autoplay", Companyvideo_Autoplay);
            ucCompanyvideo.Render(context, "gxmediaplayer", Companyvideo_Internalname, "COMPANYVIDEOContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LandingPurusFeaturesCell1", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFeaturessection2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop80", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturestitle2_Internalname, "¿Quienes Somos?", "", "", lblFeaturestitle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWhiteWithUnderline1", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturessubtitle12_Internalname, "Nuestro Modelo de Negocios esta basado en una red de Profesionales, bajo un esquema de Colaboracion y Complemento, Permitiendonos:", "", "", lblFeaturessubtitle12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitleWhite1", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturessubtitle22_Internalname, "Brindar Asesoramiento experto a nuestros Clientes", "", "", lblFeaturessubtitle22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitleWhite1", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturessubtitle222_Internalname, "Operar con esquemas flexibles de pricing (desde valores fijos a mixtos incluyendo porcentajes sobre resultados)", "", "", lblFeaturessubtitle222_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitleWhite1", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturessubtitle2222_Internalname, "Somos una red de amigos, y ex colegas donde cada uno conoce en profundidad las virtudes del otro, Permitiendonos crear soluciones con importantes sinergias entre las diferentes areas de una compañia", "", "", lblFeaturessubtitle2222_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitleWhite1", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50 CellPaddingBottom80", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "LandingPurusImageServices";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "1257f17b-3b29-4041-ac68-fb742a9db739", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLandindpurusfeaturesleft2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "LandingPurusImageServices";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e74fe1b4-7574-43e8-9fc1-b1ec0471946c", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLandingpurusfeaturescenter2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "LandingPurusImageServices";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "d3ec2195-a4b4-4bf6-8be8-20f677e43e8d", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLandingpurusfeaturesright2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LandingPurusFeaturesCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFeaturessection_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop80", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturestitle_Internalname, "Nuestros Servicios", "", "", lblFeaturestitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWhiteWithUnderline", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturessubtitle1_Internalname, "Enfoque de Asesoria Parcial o Integral", "", "", lblFeaturessubtitle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitleWhite", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturessubtitle2_Internalname, "Planes de Mejora de Resultados", "", "", lblFeaturessubtitle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitleWhite", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturessubtitle2a_Internalname, "Resultados Financieros Sostenibles", "", "", lblFeaturessubtitle2a_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitleWhite", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFeaturessubtitle2aw_Internalname, "Gestion en Tiempo Real", "", "", lblFeaturessubtitle2aw_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitleWhite", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50 CellPaddingBottom80", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "LandingPurusImageServices";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "78670b14-efc4-4980-831d-356c3c810d81", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLandindpurusfeaturesleft_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "LandingPurusImageServices";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "856199ee-f88f-4935-9c1f-d16a2e3a9137", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLandingpurusfeaturescenter_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "LandingPurusImageServices";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "f171d67b-0e4e-4127-98dc-f332c99f16a3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLandingpurusfeaturesright_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divStudiossection_Internalname, 1, 0, "px", 0, "px", "TableContentLandingPurus", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop80", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblStudiostitle_Internalname, "Studios", "", "", lblStudiostitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWithUnderline", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblStudiossubtitle_Internalname, "We created work studios to build solid business solutions, where each team combines experience with a deep knowledge about technology and best practices.", "", "", lblStudiossubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom80", "left", "top", "", "", "div");
            /*  Grid Control  */
            StudiosgridContainer.SetIsFreestyle(true);
            StudiosgridContainer.SetWrapped(nGXWrapped);
            if ( StudiosgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"StudiosgridContainer"+"DivS\" data-gxgridid=\"124\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subStudiosgrid_Internalname, subStudiosgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               StudiosgridContainer.AddObjectProperty("GridName", "Studiosgrid");
            }
            else
            {
               StudiosgridContainer.AddObjectProperty("GridName", "Studiosgrid");
               StudiosgridContainer.AddObjectProperty("Header", subStudiosgrid_Header);
               StudiosgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               StudiosgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
               StudiosgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               StudiosgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               StudiosgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStudiosgrid_Backcolorstyle), 1, 0, ".", "")));
               StudiosgridContainer.AddObjectProperty("CmpContext", "");
               StudiosgridContainer.AddObjectProperty("InMasterPage", "false");
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtlandingpurusstudiosample__studiotitle_Enabled), 5, 0, ".", "")));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               StudiosgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtlandingpurusstudiosample__studiodescription_Enabled), 5, 0, ".", "")));
               StudiosgridContainer.AddColumnProperties(StudiosgridColumn);
               StudiosgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStudiosgrid_Selectedindex), 4, 0, ".", "")));
               StudiosgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStudiosgrid_Allowselection), 1, 0, ".", "")));
               StudiosgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStudiosgrid_Selectioncolor), 9, 0, ".", "")));
               StudiosgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStudiosgrid_Allowhovering), 1, 0, ".", "")));
               StudiosgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStudiosgrid_Hoveringcolor), 9, 0, ".", "")));
               StudiosgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStudiosgrid_Allowcollapsing), 1, 0, ".", "")));
               StudiosgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStudiosgrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 124 )
         {
            wbEnd = 0;
            nRC_GXsfl_124 = (int)(nGXsfl_124_idx-1);
            if ( StudiosgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV22GXV1 = nGXsfl_124_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"StudiosgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Studiosgrid", StudiosgridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "StudiosgridContainerData", StudiosgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "StudiosgridContainerData"+"V", StudiosgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"StudiosgridContainerData"+"V"+"\" value='"+StudiosgridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg CellPaddingBottom80", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientssection_Internalname, 1, 0, "px", 0, "px", "TableContentLandingPurusHorizontalGrid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg CellPaddingTop80", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblClientstitle_Internalname, "Customers", "", "", lblClientstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWithUnderline", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg CellPaddingTop50 CellPaddingBottom50", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCustomerssubtitle_Internalname, "Some of the companies that have relied on us.", "", "", lblCustomerssubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusSubtitle", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg LandingPurusCustomersHGridCell", "left", "top", "", "", "div");
            /*  Grid Control  */
            CustomersgridContainer.SetIsFreestyle(true);
            CustomersgridContainer.SetWrapped(nGXWrapped);
            if ( CustomersgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"CustomersgridContainer"+"DivS\" data-gxgridid=\"149\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subCustomersgrid_Internalname, subCustomersgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               CustomersgridContainer.AddObjectProperty("GridName", "Customersgrid");
            }
            else
            {
               CustomersgridContainer.AddObjectProperty("GridName", "Customersgrid");
               CustomersgridContainer.AddObjectProperty("Header", subCustomersgrid_Header);
               CustomersgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               CustomersgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
               CustomersgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Backcolorstyle), 1, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("CmpContext", "");
               CustomersgridContainer.AddObjectProperty("InMasterPage", "false");
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               CustomersgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthomelandingsamplelogos__logo_Enabled), 5, 0, ".", "")));
               CustomersgridContainer.AddColumnProperties(CustomersgridColumn);
               CustomersgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Selectedindex), 4, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Allowselection), 1, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Selectioncolor), 9, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Allowhovering), 1, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Hoveringcolor), 9, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Allowcollapsing), 1, 0, ".", "")));
               CustomersgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 149 )
         {
            wbEnd = 0;
            nRC_GXsfl_149 = (int)(nGXsfl_149_idx-1);
            if ( CustomersgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV26GXV5 = nGXsfl_149_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"CustomersgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Customersgrid", CustomersgridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CustomersgridContainerData", CustomersgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CustomersgridContainerData"+"V", CustomersgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CustomersgridContainerData"+"V"+"\" value='"+CustomersgridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LandingPurusTestimonialsCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTestimonialssection_Internalname, 1, 0, "px", 0, "px", "TableContentLandingPurusTestimonials", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTestimonialstitle_Internalname, "Nuestro Proyecto", "", "", lblTestimonialstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWhiteWithUnderline", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Home.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "left", "top", "", "", "div");
            /*  Grid Control  */
            FstestimonialsContainer.SetIsFreestyle(true);
            FstestimonialsContainer.SetWrapped(nGXWrapped);
            if ( FstestimonialsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"FstestimonialsContainer"+"DivS\" data-gxgridid=\"163\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subFstestimonials_Internalname, subFstestimonials_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               FstestimonialsContainer.AddObjectProperty("GridName", "Fstestimonials");
            }
            else
            {
               FstestimonialsContainer.AddObjectProperty("GridName", "Fstestimonials");
               FstestimonialsContainer.AddObjectProperty("Header", subFstestimonials_Header);
               FstestimonialsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               FstestimonialsContainer.AddObjectProperty("Class", "FreeStyleGrid");
               FstestimonialsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Backcolorstyle), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("CmpContext", "");
               FstestimonialsContainer.AddObjectProperty("InMasterPage", "false");
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthometestimonials__sdthometestimonialsdescription_Enabled), 5, 0, ".", "")));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthometestimonials__sdthometestimonialsname_Enabled), 5, 0, ".", "")));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthometestimonials__sdthometestimonialscompany_Enabled), 5, 0, ".", "")));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Selectedindex), 4, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Allowselection), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Selectioncolor), 9, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Allowhovering), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Hoveringcolor), 9, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Allowcollapsing), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 163 )
         {
            wbEnd = 0;
            nRC_GXsfl_163 = (int)(nGXsfl_163_idx-1);
            if ( FstestimonialsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV28GXV7 = nGXsfl_163_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FstestimonialsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fstestimonials", FstestimonialsContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData", FstestimonialsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData"+"V", FstestimonialsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FstestimonialsContainerData"+"V"+"\" value='"+FstestimonialsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 124 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( StudiosgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV22GXV1 = nGXsfl_124_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"StudiosgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Studiosgrid", StudiosgridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "StudiosgridContainerData", StudiosgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "StudiosgridContainerData"+"V", StudiosgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"StudiosgridContainerData"+"V"+"\" value='"+StudiosgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 149 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( CustomersgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV26GXV5 = nGXsfl_149_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"CustomersgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Customersgrid", CustomersgridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CustomersgridContainerData", CustomersgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CustomersgridContainerData"+"V", CustomersgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CustomersgridContainerData"+"V"+"\" value='"+CustomersgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 163 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FstestimonialsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV28GXV7 = nGXsfl_163_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FstestimonialsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fstestimonials", FstestimonialsContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData", FstestimonialsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData"+"V", FstestimonialsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FstestimonialsContainerData"+"V"+"\" value='"+FstestimonialsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START072( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_2-148375", 0) ;
            }
            Form.Meta.addItem("description", "Inicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP070( ) ;
      }

      protected void WS072( )
      {
         START072( ) ;
         EVT072( ) ;
      }

      protected void EVT072( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "STUDIOSGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_124_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_124_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_124_idx), 4, 0), 4, "0");
                              SubsflControlProps_1242( ) ;
                              AV22GXV1 = nGXsfl_124_idx;
                              if ( ( AV12SDTLandingPurusStudioSample.Count >= AV22GXV1 ) && ( AV22GXV1 > 0 ) )
                              {
                                 AV12SDTLandingPurusStudioSample.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem)AV12SDTLandingPurusStudioSample.Item(AV22GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "STUDIOSGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E12072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "CUSTOMERSGRID.LOAD") == 0 )
                           {
                              nGXsfl_149_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_149_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_idx), 4, 0), 4, "0");
                              SubsflControlProps_1494( ) ;
                              AV26GXV5 = nGXsfl_149_idx;
                              if ( ( AV18SDTHomeLandingSampleLogos.Count >= AV26GXV5 ) && ( AV26GXV5 > 0 ) )
                              {
                                 AV18SDTHomeLandingSampleLogos.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem)AV18SDTHomeLandingSampleLogos.Item(AV26GXV5));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "CUSTOMERSGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E13074 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FSTESTIMONIALS.LOAD") == 0 )
                           {
                              nGXsfl_163_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_163_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_163_idx), 4, 0), 4, "0");
                              SubsflControlProps_1633( ) ;
                              AV28GXV7 = nGXsfl_163_idx;
                              if ( ( AV16SDTHomeTestimonials.Count >= AV28GXV7 ) && ( AV28GXV7 > 0 ) )
                              {
                                 AV16SDTHomeTestimonials.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV16SDTHomeTestimonials.Item(AV28GXV7));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "FSTESTIMONIALS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E14073 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE072( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA072( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrStudiosgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1242( ) ;
         while ( nGXsfl_124_idx <= nRC_GXsfl_124 )
         {
            sendrow_1242( ) ;
            nGXsfl_124_idx = ((subStudiosgrid_Islastpage==1)&&(nGXsfl_124_idx+1>subStudiosgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_124_idx+1);
            sGXsfl_124_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_124_idx), 4, 0), 4, "0");
            SubsflControlProps_1242( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( StudiosgridContainer)) ;
         /* End function gxnrStudiosgrid_newrow */
      }

      protected void gxnrFstestimonials_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1633( ) ;
         while ( nGXsfl_163_idx <= nRC_GXsfl_163 )
         {
            sendrow_1633( ) ;
            nGXsfl_163_idx = ((subFstestimonials_Islastpage==1)&&(nGXsfl_163_idx+1>subFstestimonials_fnc_Recordsperpage( )) ? 1 : nGXsfl_163_idx+1);
            sGXsfl_163_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_163_idx), 4, 0), 4, "0");
            SubsflControlProps_1633( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FstestimonialsContainer)) ;
         /* End function gxnrFstestimonials_newrow */
      }

      protected void gxnrCustomersgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1494( ) ;
         while ( nGXsfl_149_idx <= nRC_GXsfl_149 )
         {
            sendrow_1494( ) ;
            nGXsfl_149_idx = ((subCustomersgrid_Islastpage==1)&&(nGXsfl_149_idx+1>subCustomersgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_149_idx+1);
            sGXsfl_149_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_idx), 4, 0), 4, "0");
            SubsflControlProps_1494( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( CustomersgridContainer)) ;
         /* End function gxnrCustomersgrid_newrow */
      }

      protected void gxgrStudiosgrid_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         STUDIOSGRID_nCurrentRecord = 0;
         RF072( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrStudiosgrid_refresh */
      }

      protected void gxgrCustomersgrid_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         CUSTOMERSGRID_nCurrentRecord = 0;
         RF074( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrCustomersgrid_refresh */
      }

      protected void gxgrFstestimonials_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSTESTIMONIALS_nCurrentRecord = 0;
         RF073( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFstestimonials_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF072( ) ;
         RF074( ) ;
         RF073( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtlandingpurusstudiosample__studiotitle_Enabled = 0;
         AssignProp("", false, edtavSdtlandingpurusstudiosample__studiotitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtlandingpurusstudiosample__studiotitle_Enabled), 5, 0), !bGXsfl_124_Refreshing);
         edtavSdtlandingpurusstudiosample__studiodescription_Enabled = 0;
         AssignProp("", false, edtavSdtlandingpurusstudiosample__studiodescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtlandingpurusstudiosample__studiodescription_Enabled), 5, 0), !bGXsfl_124_Refreshing);
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsdescription_Enabled), 5, 0), !bGXsfl_163_Refreshing);
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsname_Enabled), 5, 0), !bGXsfl_163_Refreshing);
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialscompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialscompany_Enabled), 5, 0), !bGXsfl_163_Refreshing);
      }

      protected void RF072( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            StudiosgridContainer.ClearRows();
         }
         wbStart = 124;
         nGXsfl_124_idx = 1;
         sGXsfl_124_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_124_idx), 4, 0), 4, "0");
         SubsflControlProps_1242( ) ;
         bGXsfl_124_Refreshing = true;
         StudiosgridContainer.AddObjectProperty("GridName", "Studiosgrid");
         StudiosgridContainer.AddObjectProperty("CmpContext", "");
         StudiosgridContainer.AddObjectProperty("InMasterPage", "false");
         StudiosgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         StudiosgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         StudiosgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         StudiosgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         StudiosgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subStudiosgrid_Backcolorstyle), 1, 0, ".", "")));
         StudiosgridContainer.PageSize = subStudiosgrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1242( ) ;
            E12072 ();
            wbEnd = 124;
            WB070( ) ;
         }
         bGXsfl_124_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes072( )
      {
      }

      protected void RF073( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FstestimonialsContainer.ClearRows();
         }
         wbStart = 163;
         nGXsfl_163_idx = 1;
         sGXsfl_163_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_163_idx), 4, 0), 4, "0");
         SubsflControlProps_1633( ) ;
         bGXsfl_163_Refreshing = true;
         FstestimonialsContainer.AddObjectProperty("GridName", "Fstestimonials");
         FstestimonialsContainer.AddObjectProperty("CmpContext", "");
         FstestimonialsContainer.AddObjectProperty("InMasterPage", "false");
         FstestimonialsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FstestimonialsContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FstestimonialsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FstestimonialsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FstestimonialsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Backcolorstyle), 1, 0, ".", "")));
         FstestimonialsContainer.PageSize = subFstestimonials_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1633( ) ;
            E14073 ();
            wbEnd = 163;
            WB070( ) ;
         }
         bGXsfl_163_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes073( )
      {
      }

      protected void RF074( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            CustomersgridContainer.ClearRows();
         }
         wbStart = 149;
         nGXsfl_149_idx = 1;
         sGXsfl_149_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_idx), 4, 0), 4, "0");
         SubsflControlProps_1494( ) ;
         bGXsfl_149_Refreshing = true;
         CustomersgridContainer.AddObjectProperty("GridName", "Customersgrid");
         CustomersgridContainer.AddObjectProperty("CmpContext", "");
         CustomersgridContainer.AddObjectProperty("InMasterPage", "false");
         CustomersgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         CustomersgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         CustomersgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         CustomersgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         CustomersgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCustomersgrid_Backcolorstyle), 1, 0, ".", "")));
         CustomersgridContainer.PageSize = subCustomersgrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1494( ) ;
            E13074 ();
            wbEnd = 149;
            WB070( ) ;
         }
         bGXsfl_149_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes074( )
      {
      }

      protected int subStudiosgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subStudiosgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subStudiosgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subStudiosgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subCustomersgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subCustomersgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subCustomersgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subCustomersgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavSdtlandingpurusstudiosample__studiotitle_Enabled = 0;
         AssignProp("", false, edtavSdtlandingpurusstudiosample__studiotitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtlandingpurusstudiosample__studiotitle_Enabled), 5, 0), !bGXsfl_124_Refreshing);
         edtavSdtlandingpurusstudiosample__studiodescription_Enabled = 0;
         AssignProp("", false, edtavSdtlandingpurusstudiosample__studiodescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtlandingpurusstudiosample__studiodescription_Enabled), 5, 0), !bGXsfl_124_Refreshing);
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsdescription_Enabled), 5, 0), !bGXsfl_163_Refreshing);
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsname_Enabled), 5, 0), !bGXsfl_163_Refreshing);
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialscompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialscompany_Enabled), 5, 0), !bGXsfl_163_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP070( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11072 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtlandingpurusstudiosample"), AV12SDTLandingPurusStudioSample);
            ajax_req_read_hidden_sdt(cgiGet( "Sdthometestimonials"), AV16SDTHomeTestimonials);
            ajax_req_read_hidden_sdt(cgiGet( "Sdthomelandingsamplelogos"), AV18SDTHomeLandingSampleLogos);
            /* Read saved values. */
            nRC_GXsfl_124 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_124"), ",", "."));
            nRC_GXsfl_149 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_149"), ",", "."));
            nRC_GXsfl_163 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_163"), ",", "."));
            Companyvideo_Width = cgiGet( "COMPANYVIDEO_Width");
            Companyvideo_Height = cgiGet( "COMPANYVIDEO_Height");
            Companyvideo_Source = cgiGet( "COMPANYVIDEO_Source");
            Companyvideo_Autoplay = cgiGet( "COMPANYVIDEO_Autoplay");
            subStudiosgrid_Class = cgiGet( "STUDIOSGRID_Class");
            subStudiosgrid_Flexwrap = cgiGet( "STUDIOSGRID_Flexwrap");
            subStudiosgrid_Justifycontent = cgiGet( "STUDIOSGRID_Justifycontent");
            subStudiosgrid_Aligncontent = cgiGet( "STUDIOSGRID_Aligncontent");
            subCustomersgrid_Class = cgiGet( "CUSTOMERSGRID_Class");
            subCustomersgrid_Showpagecontroller = cgiGet( "CUSTOMERSGRID_Showpagecontroller");
            subCustomersgrid_Infinite = cgiGet( "CUSTOMERSGRID_Infinite");
            subCustomersgrid_Autoplay = cgiGet( "CUSTOMERSGRID_Autoplay");
            subFstestimonials_Class = cgiGet( "FSTESTIMONIALS_Class");
            nRC_GXsfl_124 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_124"), ",", "."));
            nGXsfl_124_fel_idx = 0;
            while ( nGXsfl_124_fel_idx < nRC_GXsfl_124 )
            {
               nGXsfl_124_fel_idx = ((subStudiosgrid_Islastpage==1)&&(nGXsfl_124_fel_idx+1>subStudiosgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_124_fel_idx+1);
               sGXsfl_124_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_124_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1242( ) ;
               AV22GXV1 = nGXsfl_124_fel_idx;
               if ( ( AV12SDTLandingPurusStudioSample.Count >= AV22GXV1 ) && ( AV22GXV1 > 0 ) )
               {
                  AV12SDTLandingPurusStudioSample.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem)AV12SDTLandingPurusStudioSample.Item(AV22GXV1));
               }
            }
            if ( nGXsfl_124_fel_idx == 0 )
            {
               nGXsfl_124_idx = 1;
               sGXsfl_124_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_124_idx), 4, 0), 4, "0");
               SubsflControlProps_1242( ) ;
            }
            nGXsfl_124_fel_idx = 1;
            nRC_GXsfl_149 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_149"), ",", "."));
            nGXsfl_149_fel_idx = 0;
            while ( nGXsfl_149_fel_idx < nRC_GXsfl_149 )
            {
               nGXsfl_149_fel_idx = ((subCustomersgrid_Islastpage==1)&&(nGXsfl_149_fel_idx+1>subCustomersgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_149_fel_idx+1);
               sGXsfl_149_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1494( ) ;
               AV26GXV5 = nGXsfl_149_fel_idx;
               if ( ( AV18SDTHomeLandingSampleLogos.Count >= AV26GXV5 ) && ( AV26GXV5 > 0 ) )
               {
                  AV18SDTHomeLandingSampleLogos.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem)AV18SDTHomeLandingSampleLogos.Item(AV26GXV5));
               }
            }
            if ( nGXsfl_149_fel_idx == 0 )
            {
               nGXsfl_149_idx = 1;
               sGXsfl_149_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_idx), 4, 0), 4, "0");
               SubsflControlProps_1494( ) ;
            }
            nGXsfl_149_fel_idx = 1;
            nRC_GXsfl_163 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_163"), ",", "."));
            nGXsfl_163_fel_idx = 0;
            while ( nGXsfl_163_fel_idx < nRC_GXsfl_163 )
            {
               nGXsfl_163_fel_idx = ((subFstestimonials_Islastpage==1)&&(nGXsfl_163_fel_idx+1>subFstestimonials_fnc_Recordsperpage( )) ? 1 : nGXsfl_163_fel_idx+1);
               sGXsfl_163_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_163_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1633( ) ;
               AV28GXV7 = nGXsfl_163_fel_idx;
               if ( ( AV16SDTHomeTestimonials.Count >= AV28GXV7 ) && ( AV28GXV7 > 0 ) )
               {
                  AV16SDTHomeTestimonials.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV16SDTHomeTestimonials.Item(AV28GXV7));
               }
            }
            if ( nGXsfl_163_fel_idx == 0 )
            {
               nGXsfl_163_idx = 1;
               sGXsfl_163_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_163_idx), 4, 0), 4, "0");
               SubsflControlProps_1633( ) ;
            }
            nGXsfl_163_fel_idx = 1;
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11072 ();
         if (returnInSub) return;
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         AV32Companyvideo_GXI = "https://youtu.be/pGcoKBBrK14";
         AV11CompanyVideo = "";
         GXt_objcol_SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem1 = AV12SDTLandingPurusStudioSample;
         new GeneXus.Programs.wwpbaseobjects.landingpurusstudiosamples(context ).execute( out  GXt_objcol_SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem1) ;
         AV12SDTLandingPurusStudioSample = GXt_objcol_SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem1;
         gx_BV124 = true;
         GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2 = AV16SDTHomeTestimonials;
         new GeneXus.Programs.wwpbaseobjects.hometestimonials(context ).execute( out  GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2) ;
         AV16SDTHomeTestimonials = GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2;
         gx_BV163 = true;
         GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem3 = AV18SDTHomeLandingSampleLogos;
         new GeneXus.Programs.wwpbaseobjects.homelandingcustomerlogos(context ).execute( out  GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem3) ;
         AV18SDTHomeLandingSampleLogos = GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem3;
         gx_BV149 = true;
         subCustomersgrid_Autoplay = StringUtil.BoolToStr( true);
         AssignProp("", false, "CustomersgridContainerDiv", "AutoPlay", subCustomersgrid_Autoplay, true);
         subCustomersgrid_Showpagecontroller = StringUtil.BoolToStr( false);
         AssignProp("", false, "CustomersgridContainerDiv", "ShowPageController", subCustomersgrid_Showpagecontroller, true);
         subCustomersgrid_Infinite = StringUtil.BoolToStr( true);
         AssignProp("", false, "CustomersgridContainerDiv", "Infinite", subCustomersgrid_Infinite, true);
         AV19WebSession.Set("IsLandingPage", "S");
      }

      private void E12072( )
      {
         /* Studiosgrid_Load Routine */
         returnInSub = false;
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV12SDTLandingPurusStudioSample.Count )
         {
            AV12SDTLandingPurusStudioSample.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem)AV12SDTLandingPurusStudioSample.Item(AV22GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 124;
            }
            sendrow_1242( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_124_Refreshing )
            {
               context.DoAjaxLoad(124, StudiosgridRow);
            }
            AV22GXV1 = (int)(AV22GXV1+1);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         divMainnumberssection_Visible = (((1==2)) ? 1 : 0);
         AssignProp("", false, divMainnumberssection_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divMainnumberssection_Visible), 5, 0), true);
         divVideosection_Visible = (((1==2)) ? 1 : 0);
         AssignProp("", false, divVideosection_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divVideosection_Visible), 5, 0), true);
      }

      private void E14073( )
      {
         /* Fstestimonials_Load Routine */
         returnInSub = false;
         AV28GXV7 = 1;
         while ( AV28GXV7 <= AV16SDTHomeTestimonials.Count )
         {
            AV16SDTHomeTestimonials.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV16SDTHomeTestimonials.Item(AV28GXV7));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 163;
            }
            sendrow_1633( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_163_Refreshing )
            {
               context.DoAjaxLoad(163, FstestimonialsRow);
            }
            AV28GXV7 = (int)(AV28GXV7+1);
         }
      }

      private void E13074( )
      {
         /* Customersgrid_Load Routine */
         returnInSub = false;
         AV26GXV5 = 1;
         while ( AV26GXV5 <= AV18SDTHomeLandingSampleLogos.Count )
         {
            AV18SDTHomeLandingSampleLogos.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem)AV18SDTHomeLandingSampleLogos.Item(AV26GXV5));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 149;
            }
            sendrow_1494( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_149_Refreshing )
            {
               context.DoAjaxLoad(149, CustomersgridRow);
            }
            AV26GXV5 = (int)(AV26GXV5+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA072( ) ;
         WS072( ) ;
         WE072( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("GXMediaPlayer/lib/video-js.css", "");
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20219151905419", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wwpbaseobjects/home.js", "?20219151905419", false, true);
            context.AddJavascriptSource("GXMediaPlayer/lib/video.min.js", "", false, true);
            context.AddJavascriptSource("GXMediaPlayer/GXMediaPlayerRender.js", "", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1242( )
      {
         edtavSdtlandingpurusstudiosample__studioimage_Internalname = "SDTLANDINGPURUSSTUDIOSAMPLE__STUDIOIMAGE_"+sGXsfl_124_idx;
         edtavSdtlandingpurusstudiosample__studiotitle_Internalname = "SDTLANDINGPURUSSTUDIOSAMPLE__STUDIOTITLE_"+sGXsfl_124_idx;
         edtavSdtlandingpurusstudiosample__studiodescription_Internalname = "SDTLANDINGPURUSSTUDIOSAMPLE__STUDIODESCRIPTION_"+sGXsfl_124_idx;
      }

      protected void SubsflControlProps_fel_1242( )
      {
         edtavSdtlandingpurusstudiosample__studioimage_Internalname = "SDTLANDINGPURUSSTUDIOSAMPLE__STUDIOIMAGE_"+sGXsfl_124_fel_idx;
         edtavSdtlandingpurusstudiosample__studiotitle_Internalname = "SDTLANDINGPURUSSTUDIOSAMPLE__STUDIOTITLE_"+sGXsfl_124_fel_idx;
         edtavSdtlandingpurusstudiosample__studiodescription_Internalname = "SDTLANDINGPURUSSTUDIOSAMPLE__STUDIODESCRIPTION_"+sGXsfl_124_fel_idx;
      }

      protected void sendrow_1242( )
      {
         SubsflControlProps_1242( ) ;
         WB070( ) ;
         StudiosgridRow = GXWebRow.GetNew(context,StudiosgridContainer);
         if ( subStudiosgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subStudiosgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subStudiosgrid_Class, "") != 0 )
            {
               subStudiosgrid_Linesclass = subStudiosgrid_Class+"Odd";
            }
         }
         else if ( subStudiosgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subStudiosgrid_Backstyle = 0;
            subStudiosgrid_Backcolor = subStudiosgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subStudiosgrid_Class, "") != 0 )
            {
               subStudiosgrid_Linesclass = subStudiosgrid_Class+"Uniform";
            }
         }
         else if ( subStudiosgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subStudiosgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subStudiosgrid_Class, "") != 0 )
            {
               subStudiosgrid_Linesclass = subStudiosgrid_Class+"Odd";
            }
            subStudiosgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subStudiosgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subStudiosgrid_Backstyle = 1;
            subStudiosgrid_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subStudiosgrid_Class, "") != 0 )
            {
               subStudiosgrid_Linesclass = subStudiosgrid_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsstudiosgrid_Internalname+"_"+sGXsfl_124_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable2_Internalname+"_"+sGXsfl_124_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"left",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"flex-direction:column;align-items:center;",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Attribute/Variable Label */
         StudiosgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Studio Image",(string)"gx-form-item AttributeLandingPurusStudioImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Static Bitmap Variable */
         ClassString = "AttributeLandingPurusStudioImage";
         StyleString = "";
         sImgUrl = context.PathToRelativeUrl( ((GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem)AV12SDTLandingPurusStudioSample.Item(AV22GXV1)).gxTpr_Studioimage);
         StudiosgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtlandingpurusstudiosample__studioimage_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Attribute/Variable Label */
         StudiosgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtlandingpurusstudiosample__studiotitle_Internalname,(string)"Studio Title",(string)"gx-form-item AttributeLandingPurusSimpleTitleLabel",(short)0,(bool)true,(string)"width: 25%;"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Single line edit */
         ROClassString = "AttributeLandingPurusSimpleTitle";
         StudiosgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtlandingpurusstudiosample__studiotitle_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem)AV12SDTLandingPurusStudioSample.Item(AV22GXV1)).gxTpr_Studiotitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtlandingpurusstudiosample__studiotitle_Jsonclick,(short)0,(string)"AttributeLandingPurusSimpleTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdtlandingpurusstudiosample__studiotitle_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)124,(short)1,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellPaddingTop10",(string)"left",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Div Control */
         StudiosgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Attribute/Variable Label */
         StudiosgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdtlandingpurusstudiosample__studiodescription_Internalname,(string)"Studio Description",(string)"gx-form-item AttributeLandingPurusSubtitleLabel",(short)0,(bool)true,(string)"width: 25%;"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         /* Multiple line edit */
         ClassString = "AttributeLandingPurusSubtitle";
         StyleString = "";
         ClassString = "AttributeLandingPurusSubtitle";
         StyleString = "";
         StudiosgridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtlandingpurusstudiosample__studiodescription_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem)AV12SDTLandingPurusStudioSample.Item(AV22GXV1)).gxTpr_Studiodescription,(string)"",(string)"",(short)0,(short)1,(int)edtavSdtlandingpurusstudiosample__studiodescription_Enabled,(short)0,(short)80,(string)"chr",(short)5,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"400",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)false,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         StudiosgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         StudiosgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         StudiosgridRow.AddRenderProperties(StudiosgridColumn);
         send_integrity_lvl_hashes072( ) ;
         /* End of Columns property logic. */
         StudiosgridContainer.AddRow(StudiosgridRow);
         nGXsfl_124_idx = ((subStudiosgrid_Islastpage==1)&&(nGXsfl_124_idx+1>subStudiosgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_124_idx+1);
         sGXsfl_124_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_124_idx), 4, 0), 4, "0");
         SubsflControlProps_1242( ) ;
         /* End function sendrow_1242 */
      }

      protected void SubsflControlProps_1494( )
      {
         edtavSdthomelandingsamplelogos__logo_Internalname = "SDTHOMELANDINGSAMPLELOGOS__LOGO_"+sGXsfl_149_idx;
      }

      protected void SubsflControlProps_fel_1494( )
      {
         edtavSdthomelandingsamplelogos__logo_Internalname = "SDTHOMELANDINGSAMPLELOGOS__LOGO_"+sGXsfl_149_fel_idx;
      }

      protected void sendrow_1494( )
      {
         SubsflControlProps_1494( ) ;
         WB070( ) ;
         CustomersgridRow = GXWebRow.GetNew(context,CustomersgridContainer);
         if ( subCustomersgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subCustomersgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subCustomersgrid_Class, "") != 0 )
            {
               subCustomersgrid_Linesclass = subCustomersgrid_Class+"Odd";
            }
         }
         else if ( subCustomersgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subCustomersgrid_Backstyle = 0;
            subCustomersgrid_Backcolor = subCustomersgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subCustomersgrid_Class, "") != 0 )
            {
               subCustomersgrid_Linesclass = subCustomersgrid_Class+"Uniform";
            }
         }
         else if ( subCustomersgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subCustomersgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subCustomersgrid_Class, "") != 0 )
            {
               subCustomersgrid_Linesclass = subCustomersgrid_Class+"Odd";
            }
            subCustomersgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subCustomersgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subCustomersgrid_Backstyle = 1;
            if ( ((int)((nGXsfl_149_idx) % (2))) == 0 )
            {
               subCustomersgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subCustomersgrid_Class, "") != 0 )
               {
                  subCustomersgrid_Linesclass = subCustomersgrid_Class+"Even";
               }
            }
            else
            {
               subCustomersgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subCustomersgrid_Class, "") != 0 )
               {
                  subCustomersgrid_Linesclass = subCustomersgrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( CustomersgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subCustomersgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_149_idx+"\">") ;
         }
         /* Table start */
         CustomersgridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablefscustomersgrid_Internalname+"_"+sGXsfl_149_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         CustomersgridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         CustomersgridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         /* Div Control */
         CustomersgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         /* Attribute/Variable Label */
         CustomersgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Logo",(string)"gx-form-item AttributeLandingPurusCustomersImageLabel",(short)0,(bool)true,(string)"width: 25%;"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         /* Static Bitmap Variable */
         ClassString = "AttributeLandingPurusCustomersImage";
         StyleString = "";
         sImgUrl = context.PathToRelativeUrl( ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem)AV18SDTHomeLandingSampleLogos.Item(AV26GXV5)).gxTpr_Logo);
         CustomersgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthomelandingsamplelogos__logo_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(int)edtavSdthomelandingsamplelogos__logo_Enabled,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         CustomersgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CustomersgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CustomersgridRow.AddRenderProperties(CustomersgridColumn);
         if ( CustomersgridContainer.GetWrapped() == 1 )
         {
            CustomersgridContainer.CloseTag("cell");
         }
         if ( CustomersgridContainer.GetWrapped() == 1 )
         {
            CustomersgridContainer.CloseTag("row");
         }
         if ( CustomersgridContainer.GetWrapped() == 1 )
         {
            CustomersgridContainer.CloseTag("table");
         }
         /* End of table */
         send_integrity_lvl_hashes074( ) ;
         /* End of Columns property logic. */
         CustomersgridContainer.AddRow(CustomersgridRow);
         nGXsfl_149_idx = ((subCustomersgrid_Islastpage==1)&&(nGXsfl_149_idx+1>subCustomersgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_149_idx+1);
         sGXsfl_149_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_149_idx), 4, 0), 4, "0");
         SubsflControlProps_1494( ) ;
         /* End function sendrow_1494 */
      }

      protected void SubsflControlProps_1633( )
      {
         edtavSdthometestimonials__sdthometestimonialsdescription_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION_"+sGXsfl_163_idx;
         edtavSdthometestimonials__sdthometestimonialsname_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME_"+sGXsfl_163_idx;
         edtavSdthometestimonials__sdthometestimonialscompany_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY_"+sGXsfl_163_idx;
      }

      protected void SubsflControlProps_fel_1633( )
      {
         edtavSdthometestimonials__sdthometestimonialsdescription_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION_"+sGXsfl_163_fel_idx;
         edtavSdthometestimonials__sdthometestimonialsname_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME_"+sGXsfl_163_fel_idx;
         edtavSdthometestimonials__sdthometestimonialscompany_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY_"+sGXsfl_163_fel_idx;
      }

      protected void sendrow_1633( )
      {
         SubsflControlProps_1633( ) ;
         WB070( ) ;
         FstestimonialsRow = GXWebRow.GetNew(context,FstestimonialsContainer);
         if ( subFstestimonials_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFstestimonials_Backstyle = 0;
            if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
            {
               subFstestimonials_Linesclass = subFstestimonials_Class+"Odd";
            }
         }
         else if ( subFstestimonials_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFstestimonials_Backstyle = 0;
            subFstestimonials_Backcolor = subFstestimonials_Allbackcolor;
            if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
            {
               subFstestimonials_Linesclass = subFstestimonials_Class+"Uniform";
            }
         }
         else if ( subFstestimonials_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFstestimonials_Backstyle = 1;
            if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
            {
               subFstestimonials_Linesclass = subFstestimonials_Class+"Odd";
            }
            subFstestimonials_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFstestimonials_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFstestimonials_Backstyle = 1;
            if ( ((int)((nGXsfl_163_idx) % (2))) == 0 )
            {
               subFstestimonials_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
               {
                  subFstestimonials_Linesclass = subFstestimonials_Class+"Even";
               }
            }
            else
            {
               subFstestimonials_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
               {
                  subFstestimonials_Linesclass = subFstestimonials_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FstestimonialsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFstestimonials_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_163_idx+"\">") ;
         }
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsfstestimonials_Internalname+"_"+sGXsfl_163_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 TableLandingPurusTestimonials",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Attribute/Variable Label */
         FstestimonialsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsdescription_Internalname,(string)"SDTHome Testimonials Description",(string)"col-sm-3 AttributeLandingPurusTestimonialDescriptionLabel",(short)0,(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Multiple line edit */
         ClassString = "AttributeLandingPurusTestimonialDescription";
         StyleString = "";
         ClassString = "AttributeLandingPurusTestimonialDescription";
         StyleString = "";
         FstestimonialsRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsdescription_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV16SDTHomeTestimonials.Item(AV28GXV7)).gxTpr_Sdthometestimonialsdescription,(string)"",(string)"",(short)0,(short)1,(int)edtavSdthometestimonials__sdthometestimonialsdescription_Enabled,(short)0,(short)80,(string)"chr",(short)5,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"400",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)false,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 LandingPurusTestimonialTitleCell",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable1_Internalname+"_"+sGXsfl_163_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Attribute/Variable Label */
         FstestimonialsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsname_Internalname,(string)"SDTHome Testimonials Name",(string)"col-sm-3 AttributeLandingPurusTestimonialTitleLabel",(short)0,(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Single line edit */
         ROClassString = "AttributeLandingPurusTestimonialTitle";
         FstestimonialsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsname_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV16SDTHomeTestimonials.Item(AV28GXV7)).gxTpr_Sdthometestimonialsname,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdthometestimonials__sdthometestimonialsname_Jsonclick,(short)0,(string)"AttributeLandingPurusTestimonialTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdthometestimonials__sdthometestimonialsname_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)163,(short)1,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Attribute/Variable Label */
         FstestimonialsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialscompany_Internalname,(string)"SDTHome Testimonials Company",(string)"col-sm-3 AttributeLandingPurusTestimonialSubtitleLabel",(short)0,(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Single line edit */
         ROClassString = "AttributeLandingPurusTestimonialSubtitle";
         FstestimonialsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialscompany_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV16SDTHomeTestimonials.Item(AV28GXV7)).gxTpr_Sdthometestimonialscompany,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdthometestimonials__sdthometestimonialscompany_Jsonclick,(short)0,(string)"AttributeLandingPurusTestimonialSubtitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdthometestimonials__sdthometestimonialscompany_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)163,(short)1,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         send_integrity_lvl_hashes073( ) ;
         /* End of Columns property logic. */
         FstestimonialsContainer.AddRow(FstestimonialsRow);
         nGXsfl_163_idx = ((subFstestimonials_Islastpage==1)&&(nGXsfl_163_idx+1>subFstestimonials_fnc_Recordsperpage( )) ? 1 : nGXsfl_163_idx+1);
         sGXsfl_163_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_163_idx), 4, 0), 4, "0");
         SubsflControlProps_1633( ) ;
         /* End function sendrow_1633 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblSlogantitle_Internalname = "SLOGANTITLE";
         lblSlogansubtitle_Internalname = "SLOGANSUBTITLE";
         divSlogansection_Internalname = "SLOGANSECTION";
         lblMainnumberstitle_Internalname = "MAINNUMBERSTITLE";
         lblMainnumberssubtitle_Internalname = "MAINNUMBERSSUBTITLE";
         imgMainnumbers_icon1_Internalname = "MAINNUMBERS_ICON1";
         lblQw_Internalname = "QW";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         imgMainnumbers_icon2_Internalname = "MAINNUMBERS_ICON2";
         lblQwasd_Internalname = "QWASD";
         divUnnamedtable7_Internalname = "UNNAMEDTABLE7";
         imgMainnumbers_icon3_Internalname = "MAINNUMBERS_ICON3";
         lblQwfd_Internalname = "QWFD";
         divUnnamedtable8_Internalname = "UNNAMEDTABLE8";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         divMainnumberssection_Internalname = "MAINNUMBERSSECTION";
         Companyvideo_Internalname = "COMPANYVIDEO";
         divVideosection_Internalname = "VIDEOSECTION";
         lblFeaturestitle2_Internalname = "FEATURESTITLE2";
         lblFeaturessubtitle12_Internalname = "FEATURESSUBTITLE12";
         lblFeaturessubtitle22_Internalname = "FEATURESSUBTITLE22";
         lblFeaturessubtitle222_Internalname = "FEATURESSUBTITLE222";
         lblFeaturessubtitle2222_Internalname = "FEATURESSUBTITLE2222";
         imgLandindpurusfeaturesleft2_Internalname = "LANDINDPURUSFEATURESLEFT2";
         imgLandingpurusfeaturescenter2_Internalname = "LANDINGPURUSFEATURESCENTER2";
         imgLandingpurusfeaturesright2_Internalname = "LANDINGPURUSFEATURESRIGHT2";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         divFeaturessection2_Internalname = "FEATURESSECTION2";
         lblFeaturestitle_Internalname = "FEATURESTITLE";
         lblFeaturessubtitle1_Internalname = "FEATURESSUBTITLE1";
         lblFeaturessubtitle2_Internalname = "FEATURESSUBTITLE2";
         lblFeaturessubtitle2a_Internalname = "FEATURESSUBTITLE2A";
         lblFeaturessubtitle2aw_Internalname = "FEATURESSUBTITLE2AW";
         imgLandindpurusfeaturesleft_Internalname = "LANDINDPURUSFEATURESLEFT";
         imgLandingpurusfeaturescenter_Internalname = "LANDINGPURUSFEATURESCENTER";
         imgLandingpurusfeaturesright_Internalname = "LANDINGPURUSFEATURESRIGHT";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divFeaturessection_Internalname = "FEATURESSECTION";
         lblStudiostitle_Internalname = "STUDIOSTITLE";
         lblStudiossubtitle_Internalname = "STUDIOSSUBTITLE";
         edtavSdtlandingpurusstudiosample__studioimage_Internalname = "SDTLANDINGPURUSSTUDIOSAMPLE__STUDIOIMAGE";
         edtavSdtlandingpurusstudiosample__studiotitle_Internalname = "SDTLANDINGPURUSSTUDIOSAMPLE__STUDIOTITLE";
         edtavSdtlandingpurusstudiosample__studiodescription_Internalname = "SDTLANDINGPURUSSTUDIOSAMPLE__STUDIODESCRIPTION";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         divUnnamedtablefsstudiosgrid_Internalname = "UNNAMEDTABLEFSSTUDIOSGRID";
         divStudiossection_Internalname = "STUDIOSSECTION";
         lblClientstitle_Internalname = "CLIENTSTITLE";
         lblCustomerssubtitle_Internalname = "CUSTOMERSSUBTITLE";
         edtavSdthomelandingsamplelogos__logo_Internalname = "SDTHOMELANDINGSAMPLELOGOS__LOGO";
         tblUnnamedtablefscustomersgrid_Internalname = "UNNAMEDTABLEFSCUSTOMERSGRID";
         divClientssection_Internalname = "CLIENTSSECTION";
         lblTestimonialstitle_Internalname = "TESTIMONIALSTITLE";
         edtavSdthometestimonials__sdthometestimonialsdescription_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION";
         edtavSdthometestimonials__sdthometestimonialsname_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME";
         edtavSdthometestimonials__sdthometestimonialscompany_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divUnnamedtablefsfstestimonials_Internalname = "UNNAMEDTABLEFSFSTESTIMONIALS";
         divTestimonialssection_Internalname = "TESTIMONIALSSECTION";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subStudiosgrid_Internalname = "STUDIOSGRID";
         subCustomersgrid_Internalname = "CUSTOMERSGRID";
         subFstestimonials_Internalname = "FSTESTIMONIALS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavSdthometestimonials__sdthometestimonialscompany_Jsonclick = "";
         edtavSdthometestimonials__sdthometestimonialsname_Jsonclick = "";
         edtavSdtlandingpurusstudiosample__studiotitle_Jsonclick = "";
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = -1;
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = -1;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = -1;
         edtavSdtlandingpurusstudiosample__studiodescription_Enabled = -1;
         edtavSdtlandingpurusstudiosample__studiotitle_Enabled = -1;
         subFstestimonials_Allowcollapsing = 0;
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         subFstestimonials_Backcolorstyle = 0;
         subCustomersgrid_Allowcollapsing = 0;
         edtavSdthomelandingsamplelogos__logo_Enabled = 0;
         subCustomersgrid_Backcolorstyle = 0;
         subStudiosgrid_Allowcollapsing = 0;
         edtavSdtlandingpurusstudiosample__studiodescription_Enabled = 0;
         edtavSdtlandingpurusstudiosample__studiotitle_Enabled = 0;
         subStudiosgrid_Backcolorstyle = 0;
         divVideosection_Visible = 1;
         divMainnumberssection_Visible = 1;
         subFstestimonials_Class = "FreeStyleGrid";
         subCustomersgrid_Autoplay = StringUtil.Str( (decimal)(0), 1, 0);
         subCustomersgrid_Infinite = StringUtil.Str( (decimal)(0), 1, 0);
         subCustomersgrid_Showpagecontroller = StringUtil.LTrimStr( (decimal)(-1), 2, 0);
         subCustomersgrid_Class = "FreeStyleGrid";
         subStudiosgrid_Aligncontent = "space-around";
         subStudiosgrid_Justifycontent = "space-around";
         subStudiosgrid_Flexwrap = "wrap";
         subStudiosgrid_Class = "FreeStyleGrid";
         Companyvideo_Autoplay = "false";
         Companyvideo_Source = "https://youtu.be/pGcoKBBrK14";
         Companyvideo_Height = "527";
         Companyvideo_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Inicio";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'STUDIOSGRID_nFirstRecordOnPage'},{av:'STUDIOSGRID_nEOF'},{av:'AV12SDTLandingPurusStudioSample',fld:'vSDTLANDINGPURUSSTUDIOSAMPLE',grid:124,pic:''},{av:'nRC_GXsfl_124',ctrl:'STUDIOSGRID',prop:'GridRC'},{av:'FSTESTIMONIALS_nFirstRecordOnPage'},{av:'FSTESTIMONIALS_nEOF'},{av:'AV16SDTHomeTestimonials',fld:'vSDTHOMETESTIMONIALS',grid:163,pic:''},{av:'nRC_GXsfl_163',ctrl:'FSTESTIMONIALS',prop:'GridRC'},{av:'CUSTOMERSGRID_nFirstRecordOnPage'},{av:'CUSTOMERSGRID_nEOF'},{av:'AV18SDTHomeLandingSampleLogos',fld:'vSDTHOMELANDINGSAMPLELOGOS',grid:149,pic:''},{av:'nRC_GXsfl_149',ctrl:'CUSTOMERSGRID',prop:'GridRC'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("FSTESTIMONIALS.LOAD","{handler:'E14073',iparms:[]");
         setEventMetadata("FSTESTIMONIALS.LOAD",",oparms:[]}");
         setEventMetadata("CUSTOMERSGRID.LOAD","{handler:'E13074',iparms:[]");
         setEventMetadata("CUSTOMERSGRID.LOAD",",oparms:[]}");
         setEventMetadata("STUDIOSGRID.LOAD","{handler:'E12072',iparms:[]");
         setEventMetadata("STUDIOSGRID.LOAD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv4',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv6',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv10',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV12SDTLandingPurusStudioSample = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem>( context, "SDTLandingPurusStudiosItem", "SsumarGroupDemo");
         AV16SDTHomeTestimonials = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem>( context, "SDTHomeTestimonialsItem", "SsumarGroupDemo");
         AV18SDTHomeLandingSampleLogos = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem>( context, "SDTHomeLandingSampleLogosItem", "SsumarGroupDemo");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblSlogantitle_Jsonclick = "";
         lblSlogansubtitle_Jsonclick = "";
         lblMainnumberstitle_Jsonclick = "";
         lblMainnumberssubtitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblQw_Jsonclick = "";
         lblQwasd_Jsonclick = "";
         lblQwfd_Jsonclick = "";
         ucCompanyvideo = new GXUserControl();
         lblFeaturestitle2_Jsonclick = "";
         lblFeaturessubtitle12_Jsonclick = "";
         lblFeaturessubtitle22_Jsonclick = "";
         lblFeaturessubtitle222_Jsonclick = "";
         lblFeaturessubtitle2222_Jsonclick = "";
         lblFeaturestitle_Jsonclick = "";
         lblFeaturessubtitle1_Jsonclick = "";
         lblFeaturessubtitle2_Jsonclick = "";
         lblFeaturessubtitle2a_Jsonclick = "";
         lblFeaturessubtitle2aw_Jsonclick = "";
         lblStudiostitle_Jsonclick = "";
         lblStudiossubtitle_Jsonclick = "";
         StudiosgridContainer = new GXWebGrid( context);
         sStyleString = "";
         subStudiosgrid_Header = "";
         StudiosgridColumn = new GXWebColumn();
         lblClientstitle_Jsonclick = "";
         lblCustomerssubtitle_Jsonclick = "";
         CustomersgridContainer = new GXWebGrid( context);
         subCustomersgrid_Header = "";
         CustomersgridColumn = new GXWebColumn();
         lblTestimonialstitle_Jsonclick = "";
         FstestimonialsContainer = new GXWebGrid( context);
         subFstestimonials_Header = "";
         FstestimonialsColumn = new GXWebColumn();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV32Companyvideo_GXI = "";
         AV11CompanyVideo = "";
         GXt_objcol_SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem>( context, "SDTLandingPurusStudiosItem", "SsumarGroupDemo");
         GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem>( context, "SDTHomeTestimonialsItem", "SsumarGroupDemo");
         GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem>( context, "SDTHomeLandingSampleLogosItem", "SsumarGroupDemo");
         AV19WebSession = context.GetSession();
         StudiosgridRow = new GXWebRow();
         FstestimonialsRow = new GXWebRow();
         CustomersgridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subStudiosgrid_Linesclass = "";
         ROClassString = "";
         subCustomersgrid_Linesclass = "";
         subFstestimonials_Linesclass = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavSdtlandingpurusstudiosample__studiotitle_Enabled = 0;
         edtavSdtlandingpurusstudiosample__studiodescription_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subStudiosgrid_Backcolorstyle ;
      private short subStudiosgrid_Allowselection ;
      private short subStudiosgrid_Allowhovering ;
      private short subStudiosgrid_Allowcollapsing ;
      private short subStudiosgrid_Collapsed ;
      private short subCustomersgrid_Backcolorstyle ;
      private short subCustomersgrid_Allowselection ;
      private short subCustomersgrid_Allowhovering ;
      private short subCustomersgrid_Allowcollapsing ;
      private short subCustomersgrid_Collapsed ;
      private short subFstestimonials_Backcolorstyle ;
      private short subFstestimonials_Allowselection ;
      private short subFstestimonials_Allowhovering ;
      private short subFstestimonials_Allowcollapsing ;
      private short subFstestimonials_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subStudiosgrid_Backstyle ;
      private short subCustomersgrid_Backstyle ;
      private short subFstestimonials_Backstyle ;
      private short STUDIOSGRID_nEOF ;
      private short FSTESTIMONIALS_nEOF ;
      private short CUSTOMERSGRID_nEOF ;
      private int nRC_GXsfl_124 ;
      private int nRC_GXsfl_149 ;
      private int nRC_GXsfl_163 ;
      private int nGXsfl_124_idx=1 ;
      private int nGXsfl_149_idx=1 ;
      private int nGXsfl_163_idx=1 ;
      private int divMainnumberssection_Visible ;
      private int divVideosection_Visible ;
      private int edtavSdtlandingpurusstudiosample__studiotitle_Enabled ;
      private int edtavSdtlandingpurusstudiosample__studiodescription_Enabled ;
      private int subStudiosgrid_Selectedindex ;
      private int subStudiosgrid_Selectioncolor ;
      private int subStudiosgrid_Hoveringcolor ;
      private int AV22GXV1 ;
      private int edtavSdthomelandingsamplelogos__logo_Enabled ;
      private int subCustomersgrid_Selectedindex ;
      private int subCustomersgrid_Selectioncolor ;
      private int subCustomersgrid_Hoveringcolor ;
      private int AV26GXV5 ;
      private int edtavSdthometestimonials__sdthometestimonialsdescription_Enabled ;
      private int edtavSdthometestimonials__sdthometestimonialsname_Enabled ;
      private int edtavSdthometestimonials__sdthometestimonialscompany_Enabled ;
      private int subFstestimonials_Selectedindex ;
      private int subFstestimonials_Selectioncolor ;
      private int subFstestimonials_Hoveringcolor ;
      private int AV28GXV7 ;
      private int subStudiosgrid_Islastpage ;
      private int subFstestimonials_Islastpage ;
      private int subCustomersgrid_Islastpage ;
      private int nGXsfl_124_fel_idx=1 ;
      private int nGXsfl_149_fel_idx=1 ;
      private int nGXsfl_163_fel_idx=1 ;
      private int idxLst ;
      private int subStudiosgrid_Backcolor ;
      private int subStudiosgrid_Allbackcolor ;
      private int subCustomersgrid_Backcolor ;
      private int subCustomersgrid_Allbackcolor ;
      private int subFstestimonials_Backcolor ;
      private int subFstestimonials_Allbackcolor ;
      private long STUDIOSGRID_nCurrentRecord ;
      private long CUSTOMERSGRID_nCurrentRecord ;
      private long FSTESTIMONIALS_nCurrentRecord ;
      private long STUDIOSGRID_nFirstRecordOnPage ;
      private long FSTESTIMONIALS_nFirstRecordOnPage ;
      private long CUSTOMERSGRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_124_idx="0001" ;
      private string sGXsfl_149_idx="0001" ;
      private string sGXsfl_163_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Companyvideo_Width ;
      private string Companyvideo_Height ;
      private string Companyvideo_Source ;
      private string Companyvideo_Autoplay ;
      private string subStudiosgrid_Class ;
      private string subStudiosgrid_Flexwrap ;
      private string subStudiosgrid_Justifycontent ;
      private string subStudiosgrid_Aligncontent ;
      private string subCustomersgrid_Class ;
      private string subCustomersgrid_Showpagecontroller ;
      private string subCustomersgrid_Infinite ;
      private string subCustomersgrid_Autoplay ;
      private string subFstestimonials_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divSlogansection_Internalname ;
      private string lblSlogantitle_Internalname ;
      private string lblSlogantitle_Jsonclick ;
      private string lblSlogansubtitle_Internalname ;
      private string lblSlogansubtitle_Jsonclick ;
      private string divMainnumberssection_Internalname ;
      private string lblMainnumberstitle_Internalname ;
      private string lblMainnumberstitle_Jsonclick ;
      private string lblMainnumberssubtitle_Internalname ;
      private string lblMainnumberssubtitle_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string divUnnamedtable6_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgMainnumbers_icon1_Internalname ;
      private string lblQw_Internalname ;
      private string lblQw_Jsonclick ;
      private string divUnnamedtable7_Internalname ;
      private string imgMainnumbers_icon2_Internalname ;
      private string lblQwasd_Internalname ;
      private string lblQwasd_Jsonclick ;
      private string divUnnamedtable8_Internalname ;
      private string imgMainnumbers_icon3_Internalname ;
      private string lblQwfd_Internalname ;
      private string lblQwfd_Jsonclick ;
      private string divVideosection_Internalname ;
      private string Companyvideo_Internalname ;
      private string divFeaturessection2_Internalname ;
      private string lblFeaturestitle2_Internalname ;
      private string lblFeaturestitle2_Jsonclick ;
      private string lblFeaturessubtitle12_Internalname ;
      private string lblFeaturessubtitle12_Jsonclick ;
      private string lblFeaturessubtitle22_Internalname ;
      private string lblFeaturessubtitle22_Jsonclick ;
      private string lblFeaturessubtitle222_Internalname ;
      private string lblFeaturessubtitle222_Jsonclick ;
      private string lblFeaturessubtitle2222_Internalname ;
      private string lblFeaturessubtitle2222_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string imgLandindpurusfeaturesleft2_Internalname ;
      private string imgLandingpurusfeaturescenter2_Internalname ;
      private string imgLandingpurusfeaturesright2_Internalname ;
      private string divFeaturessection_Internalname ;
      private string lblFeaturestitle_Internalname ;
      private string lblFeaturestitle_Jsonclick ;
      private string lblFeaturessubtitle1_Internalname ;
      private string lblFeaturessubtitle1_Jsonclick ;
      private string lblFeaturessubtitle2_Internalname ;
      private string lblFeaturessubtitle2_Jsonclick ;
      private string lblFeaturessubtitle2a_Internalname ;
      private string lblFeaturessubtitle2a_Jsonclick ;
      private string lblFeaturessubtitle2aw_Internalname ;
      private string lblFeaturessubtitle2aw_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string imgLandindpurusfeaturesleft_Internalname ;
      private string imgLandingpurusfeaturescenter_Internalname ;
      private string imgLandingpurusfeaturesright_Internalname ;
      private string divStudiossection_Internalname ;
      private string lblStudiostitle_Internalname ;
      private string lblStudiostitle_Jsonclick ;
      private string lblStudiossubtitle_Internalname ;
      private string lblStudiossubtitle_Jsonclick ;
      private string sStyleString ;
      private string subStudiosgrid_Internalname ;
      private string subStudiosgrid_Header ;
      private string divClientssection_Internalname ;
      private string lblClientstitle_Internalname ;
      private string lblClientstitle_Jsonclick ;
      private string lblCustomerssubtitle_Internalname ;
      private string lblCustomerssubtitle_Jsonclick ;
      private string subCustomersgrid_Internalname ;
      private string subCustomersgrid_Header ;
      private string divTestimonialssection_Internalname ;
      private string lblTestimonialstitle_Internalname ;
      private string lblTestimonialstitle_Jsonclick ;
      private string subFstestimonials_Internalname ;
      private string subFstestimonials_Header ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavSdtlandingpurusstudiosample__studiotitle_Internalname ;
      private string edtavSdtlandingpurusstudiosample__studiodescription_Internalname ;
      private string edtavSdthometestimonials__sdthometestimonialsdescription_Internalname ;
      private string edtavSdthometestimonials__sdthometestimonialsname_Internalname ;
      private string edtavSdthometestimonials__sdthometestimonialscompany_Internalname ;
      private string sGXsfl_124_fel_idx="0001" ;
      private string sGXsfl_149_fel_idx="0001" ;
      private string sGXsfl_163_fel_idx="0001" ;
      private string edtavSdtlandingpurusstudiosample__studioimage_Internalname ;
      private string subStudiosgrid_Linesclass ;
      private string divUnnamedtablefsstudiosgrid_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string ROClassString ;
      private string edtavSdtlandingpurusstudiosample__studiotitle_Jsonclick ;
      private string edtavSdthomelandingsamplelogos__logo_Internalname ;
      private string subCustomersgrid_Linesclass ;
      private string tblUnnamedtablefscustomersgrid_Internalname ;
      private string subFstestimonials_Linesclass ;
      private string divUnnamedtablefsfstestimonials_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string edtavSdthometestimonials__sdthometestimonialsname_Jsonclick ;
      private string edtavSdthometestimonials__sdthometestimonialscompany_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_124_Refreshing=false ;
      private bool bGXsfl_163_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_149_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV124 ;
      private bool gx_BV163 ;
      private bool gx_BV149 ;
      private string AV32Companyvideo_GXI ;
      private string AV11CompanyVideo ;
      private GXWebGrid StudiosgridContainer ;
      private GXWebGrid CustomersgridContainer ;
      private GXWebGrid FstestimonialsContainer ;
      private GXWebRow StudiosgridRow ;
      private GXWebRow FstestimonialsRow ;
      private GXWebRow CustomersgridRow ;
      private GXWebColumn StudiosgridColumn ;
      private GXWebColumn CustomersgridColumn ;
      private GXWebColumn FstestimonialsColumn ;
      private GXUserControl ucCompanyvideo ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV19WebSession ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem> AV12SDTLandingPurusStudioSample ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem> GXt_objcol_SdtSDTLandingPurusStudios_SDTLandingPurusStudiosItem1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> AV16SDTHomeTestimonials ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem> AV18SDTHomeLandingSampleLogos ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem> GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem3 ;
      private GXWebForm Form ;
   }

}
