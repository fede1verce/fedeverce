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
namespace GeneXus.Programs {
   public class nosotros : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public nosotros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public nosotros( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Banner") == 0 )
            {
               nRC_GXsfl_12 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."));
               nGXsfl_12_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."));
               sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrBanner_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Banner") == 0 )
            {
               ajax_req_read_hidden_sdt(GetNextPar( ), AV5HomeModulesSDT);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrBanner_refresh( AV5HomeModulesSDT) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridhomemodulessdts") == 0 )
            {
               nRC_GXsfl_20 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_20"), "."));
               nGXsfl_20_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_20_idx"), "."));
               sGXsfl_20_idx = GetPar( "sGXsfl_20_idx");
               edtavOptionlink_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_20_Refreshing);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridhomemodulessdts_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridhomemodulessdts") == 0 )
            {
               edtavOptionlink_Visible = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AssignProp("", false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_20_Refreshing);
               ajax_req_read_hidden_sdt(GetNextPar( ), AV5HomeModulesSDT);
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridhomemodulessdts_refresh( AV5HomeModulesSDT) ;
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
         PA0P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0P2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20219151915535", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("nosotros.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vHOMEMODULESSDT", GetSecureSignedToken( "", AV5HomeModulesSDT, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Homemodulessdt", AV5HomeModulesSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Homemodulessdt", AV5HomeModulesSDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_Homemodulessdt", GetSecureSignedToken( "", AV5HomeModulesSDT, context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_20", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_20), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vHOMEMODULESSDT", GetSecureSignedToken( "", AV5HomeModulesSDT, context));
         GxWebStd.gx_hidden_field( context, "BANNER_Class", StringUtil.RTrim( subBanner_Class));
         GxWebStd.gx_hidden_field( context, "BANNER_Showarrows", StringUtil.RTrim( subBanner_Showarrows));
         GxWebStd.gx_hidden_field( context, "BANNER_Autoplay", StringUtil.RTrim( subBanner_Autoplay));
         GxWebStd.gx_hidden_field( context, "GRIDHOMEMODULESSDTS_Class", StringUtil.RTrim( subGridhomemodulessdts_Class));
         GxWebStd.gx_hidden_field( context, "GRIDHOMEMODULESSDTS_Flexwrap", StringUtil.RTrim( subGridhomemodulessdts_Flexwrap));
         GxWebStd.gx_hidden_field( context, "GRIDHOMEMODULESSDTS_Justifycontent", StringUtil.RTrim( subGridhomemodulessdts_Justifycontent));
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
            WE0P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0P2( ) ;
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
         return formatLink("nosotros.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Nosotros" ;
      }

      public override string GetPgmdesc( )
      {
         return "Nosotros" ;
      }

      protected void WB0P0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellBannerModules", "left", "top", "", "", "div");
            /*  Grid Control  */
            BannerContainer.SetIsFreestyle(true);
            BannerContainer.SetWrapped(nGXWrapped);
            if ( BannerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"BannerContainer"+"DivS\" data-gxgridid=\"12\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subBanner_Internalname, subBanner_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               BannerContainer.AddObjectProperty("GridName", "Banner");
            }
            else
            {
               BannerContainer.AddObjectProperty("GridName", "Banner");
               BannerContainer.AddObjectProperty("Header", subBanner_Header);
               BannerContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               BannerContainer.AddObjectProperty("Class", "FreeStyleGrid");
               BannerContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               BannerContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               BannerContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subBanner_Backcolorstyle), 1, 0, ".", "")));
               BannerContainer.AddObjectProperty("CmpContext", "");
               BannerContainer.AddObjectProperty("InMasterPage", "false");
               BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               BannerContainer.AddColumnProperties(BannerColumn);
               BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               BannerContainer.AddColumnProperties(BannerColumn);
               BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               BannerContainer.AddColumnProperties(BannerColumn);
               BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               BannerContainer.AddColumnProperties(BannerColumn);
               BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               BannerColumn.AddObjectProperty("Value", context.convertURL( AV7ImageBanner));
               BannerColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavImagebanner_Enabled), 5, 0, ".", "")));
               BannerContainer.AddColumnProperties(BannerColumn);
               BannerContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subBanner_Selectedindex), 4, 0, ".", "")));
               BannerContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subBanner_Allowselection), 1, 0, ".", "")));
               BannerContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subBanner_Selectioncolor), 9, 0, ".", "")));
               BannerContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subBanner_Allowhovering), 1, 0, ".", "")));
               BannerContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subBanner_Hoveringcolor), 9, 0, ".", "")));
               BannerContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subBanner_Allowcollapsing), 1, 0, ".", "")));
               BannerContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subBanner_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( BannerContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"BannerContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Banner", BannerContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "BannerContainerData", BannerContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "BannerContainerData"+"V", BannerContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"BannerContainerData"+"V"+"\" value='"+BannerContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridhomemodulessdtsContainer.SetIsFreestyle(true);
            GridhomemodulessdtsContainer.SetWrapped(nGXWrapped);
            if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridhomemodulessdtsContainer"+"DivS\" data-gxgridid=\"20\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGridhomemodulessdts_Internalname, subGridhomemodulessdts_Internalname, "", "FreeStyleHomeModulesBig", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridhomemodulessdtsContainer.AddObjectProperty("GridName", "Gridhomemodulessdts");
            }
            else
            {
               GridhomemodulessdtsContainer.AddObjectProperty("GridName", "Gridhomemodulessdts");
               GridhomemodulessdtsContainer.AddObjectProperty("Header", subGridhomemodulessdts_Header);
               GridhomemodulessdtsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleHomeModulesBig"));
               GridhomemodulessdtsContainer.AddObjectProperty("Class", "FreeStyleHomeModulesBig");
               GridhomemodulessdtsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Backcolorstyle), 1, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("CmpContext", "");
               GridhomemodulessdtsContainer.AddObjectProperty("InMasterPage", "false");
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsColumn.AddObjectProperty("Value", lblOptionicon_Caption);
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHomemodulessdt__optiontitle_Enabled), 5, 0, ".", "")));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHomemodulessdt__optiondescription_Enabled), 5, 0, ".", "")));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridhomemodulessdtsColumn.AddObjectProperty("Value", AV6OptionLink);
               GridhomemodulessdtsColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavOptionlink_Visible), 5, 0, ".", "")));
               GridhomemodulessdtsContainer.AddColumnProperties(GridhomemodulessdtsColumn);
               GridhomemodulessdtsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Selectedindex), 4, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Allowselection), 1, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Selectioncolor), 9, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Allowhovering), 1, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Hoveringcolor), 9, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Allowcollapsing), 1, 0, ".", "")));
               GridhomemodulessdtsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            nRC_GXsfl_20 = (int)(nGXsfl_20_idx-1);
            if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV10GXV1 = nGXsfl_20_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridhomemodulessdtsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridhomemodulessdts", GridhomemodulessdtsContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridhomemodulessdtsContainerData", GridhomemodulessdtsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridhomemodulessdtsContainerData"+"V", GridhomemodulessdtsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridhomemodulessdtsContainerData"+"V"+"\" value='"+GridhomemodulessdtsContainer.GridValuesHidden()+"'/>") ;
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
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( BannerContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"BannerContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Banner", BannerContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "BannerContainerData", BannerContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "BannerContainerData"+"V", BannerContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"BannerContainerData"+"V"+"\" value='"+BannerContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 20 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV10GXV1 = nGXsfl_20_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridhomemodulessdtsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridhomemodulessdts", GridhomemodulessdtsContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridhomemodulessdtsContainerData", GridhomemodulessdtsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridhomemodulessdtsContainerData"+"V", GridhomemodulessdtsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridhomemodulessdtsContainerData"+"V"+"\" value='"+GridhomemodulessdtsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0P2( )
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
            Form.Meta.addItem("description", "Nosotros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0P0( ) ;
      }

      protected void WS0P2( )
      {
         START0P2( ) ;
         EVT0P2( ) ;
      }

      protected void EVT0P2( )
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "BANNER.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_12_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              AV7ImageBanner = cgiGet( edtavImagebanner_Internalname);
                              AssignProp("", false, edtavImagebanner_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV7ImageBanner)) ? AV13Imagebanner_GXI : context.convertURL( context.PathToRelativeUrl( AV7ImageBanner))), !bGXsfl_12_Refreshing);
                              AssignProp("", false, edtavImagebanner_Internalname, "SrcSet", context.GetImageSrcSet( AV7ImageBanner), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110P2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "BANNER.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E120P2 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "GRIDHOMEMODULESSDTS.LOAD") == 0 )
                           {
                              nGXsfl_20_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
                              SubsflControlProps_203( ) ;
                              AV10GXV1 = nGXsfl_20_idx;
                              if ( ( AV5HomeModulesSDT.Count >= AV10GXV1 ) && ( AV10GXV1 > 0 ) )
                              {
                                 AV5HomeModulesSDT.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV5HomeModulesSDT.Item(AV10GXV1));
                                 AV6OptionLink = cgiGet( edtavOptionlink_Internalname);
                                 AssignAttri("", false, edtavOptionlink_Internalname, AV6OptionLink);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDHOMEMODULESSDTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E130P3 ();
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

      protected void WE0P2( )
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

      protected void PA0P2( )
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

      protected void gxnrBanner_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subBanner_Islastpage==1)&&(nGXsfl_12_idx+1>subBanner_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( BannerContainer)) ;
         /* End function gxnrBanner_newrow */
      }

      protected void gxnrGridhomemodulessdts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_203( ) ;
         while ( nGXsfl_20_idx <= nRC_GXsfl_20 )
         {
            sendrow_203( ) ;
            nGXsfl_20_idx = ((subGridhomemodulessdts_Islastpage==1)&&(nGXsfl_20_idx+1>subGridhomemodulessdts_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
            sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
            SubsflControlProps_203( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridhomemodulessdtsContainer)) ;
         /* End function gxnrGridhomemodulessdts_newrow */
      }

      protected void gxgrBanner_refresh( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV5HomeModulesSDT )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         BANNER_nCurrentRecord = 0;
         RF0P2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrBanner_refresh */
      }

      protected void gxgrGridhomemodulessdts_refresh( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV5HomeModulesSDT )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDHOMEMODULESSDTS_nCurrentRecord = 0;
         RF0P3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridhomemodulessdts_refresh */
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
         RF0P2( ) ;
         RF0P3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavHomemodulessdt__optiontitle_Enabled = 0;
         AssignProp("", false, edtavHomemodulessdt__optiontitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomemodulessdt__optiontitle_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         edtavHomemodulessdt__optiondescription_Enabled = 0;
         AssignProp("", false, edtavHomemodulessdt__optiondescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomemodulessdt__optiondescription_Enabled), 5, 0), !bGXsfl_20_Refreshing);
      }

      protected void RF0P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            BannerContainer.ClearRows();
         }
         wbStart = 12;
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         BannerContainer.AddObjectProperty("GridName", "Banner");
         BannerContainer.AddObjectProperty("CmpContext", "");
         BannerContainer.AddObjectProperty("InMasterPage", "false");
         BannerContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         BannerContainer.AddObjectProperty("Class", "FreeStyleGrid");
         BannerContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         BannerContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         BannerContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subBanner_Backcolorstyle), 1, 0, ".", "")));
         BannerContainer.PageSize = subBanner_fnc_Recordsperpage( );
         if ( subBanner_Islastpage != 0 )
         {
            BANNER_nFirstRecordOnPage = (long)(subBanner_fnc_Recordcount( )-subBanner_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "BANNER_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(BANNER_nFirstRecordOnPage), 15, 0, ".", "")));
            BannerContainer.AddObjectProperty("BANNER_nFirstRecordOnPage", BANNER_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            E120P2 ();
            wbEnd = 12;
            WB0P0( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0P2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vHOMEMODULESSDT", AV5HomeModulesSDT);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vHOMEMODULESSDT", GetSecureSignedToken( "", AV5HomeModulesSDT, context));
      }

      protected void RF0P3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridhomemodulessdtsContainer.ClearRows();
         }
         wbStart = 20;
         nGXsfl_20_idx = 1;
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_203( ) ;
         bGXsfl_20_Refreshing = true;
         GridhomemodulessdtsContainer.AddObjectProperty("GridName", "Gridhomemodulessdts");
         GridhomemodulessdtsContainer.AddObjectProperty("CmpContext", "");
         GridhomemodulessdtsContainer.AddObjectProperty("InMasterPage", "false");
         GridhomemodulessdtsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleHomeModulesBig"));
         GridhomemodulessdtsContainer.AddObjectProperty("Class", "FreeStyleHomeModulesBig");
         GridhomemodulessdtsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridhomemodulessdtsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridhomemodulessdtsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridhomemodulessdts_Backcolorstyle), 1, 0, ".", "")));
         GridhomemodulessdtsContainer.PageSize = subGridhomemodulessdts_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_203( ) ;
            E130P3 ();
            wbEnd = 20;
            WB0P0( ) ;
         }
         bGXsfl_20_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0P3( )
      {
      }

      protected int subBanner_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subBanner_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subBanner_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subBanner_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridhomemodulessdts_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavHomemodulessdt__optiontitle_Enabled = 0;
         AssignProp("", false, edtavHomemodulessdt__optiontitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomemodulessdt__optiontitle_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         edtavHomemodulessdt__optiondescription_Enabled = 0;
         AssignProp("", false, edtavHomemodulessdt__optiondescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomemodulessdt__optiondescription_Enabled), 5, 0), !bGXsfl_20_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Homemodulessdt"), AV5HomeModulesSDT);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_12"), ",", "."));
            nRC_GXsfl_20 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_20"), ",", "."));
            subBanner_Class = cgiGet( "BANNER_Class");
            subBanner_Showarrows = cgiGet( "BANNER_Showarrows");
            subBanner_Autoplay = cgiGet( "BANNER_Autoplay");
            subGridhomemodulessdts_Class = cgiGet( "GRIDHOMEMODULESSDTS_Class");
            subGridhomemodulessdts_Flexwrap = cgiGet( "GRIDHOMEMODULESSDTS_Flexwrap");
            subGridhomemodulessdts_Justifycontent = cgiGet( "GRIDHOMEMODULESSDTS_Justifycontent");
            nRC_GXsfl_20 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_20"), ",", "."));
            nGXsfl_20_fel_idx = 0;
            while ( nGXsfl_20_fel_idx < nRC_GXsfl_20 )
            {
               nGXsfl_20_fel_idx = ((subGridhomemodulessdts_Islastpage==1)&&(nGXsfl_20_fel_idx+1>subGridhomemodulessdts_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_fel_idx+1);
               sGXsfl_20_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_203( ) ;
               AV10GXV1 = nGXsfl_20_fel_idx;
               if ( ( AV5HomeModulesSDT.Count >= AV10GXV1 ) && ( AV10GXV1 > 0 ) )
               {
                  AV5HomeModulesSDT.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV5HomeModulesSDT.Item(AV10GXV1));
                  AV6OptionLink = cgiGet( edtavOptionlink_Internalname);
               }
            }
            if ( nGXsfl_20_fel_idx == 0 )
            {
               nGXsfl_20_idx = 1;
               sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
               SubsflControlProps_203( ) ;
            }
            nGXsfl_20_fel_idx = 1;
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
         E110P2 ();
         if (returnInSub) return;
      }

      protected void E110P2( )
      {
         /* Start Routine */
         returnInSub = false;
         subBanner_Showarrows = StringUtil.BoolToStr( false);
         AssignProp("", false, "BannerContainerDiv", "ShowArrows", subBanner_Showarrows, true);
         subBanner_Autoplay = StringUtil.BoolToStr( true);
         AssignProp("", false, "BannerContainerDiv", "AutoPlay", subBanner_Autoplay, true);
         edtavOptionlink_Visible = 0;
         AssignProp("", false, edtavOptionlink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavOptionlink_Visible), 5, 0), !bGXsfl_20_Refreshing);
      }

      private void E120P2( )
      {
         /* Banner_Load Routine */
         returnInSub = false;
         AV7ImageBanner = context.GetImagePath( "7f62b544-735a-4b44-8cc2-05e3def6fade", "", context.GetTheme( ));
         AssignAttri("", false, edtavImagebanner_Internalname, AV7ImageBanner);
         AV13Imagebanner_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7f62b544-735a-4b44-8cc2-05e3def6fade", "", context.GetTheme( )));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            context.DoAjaxLoad(12, BannerRow);
         }
         AV7ImageBanner = context.GetImagePath( "7f62b544-735a-4b44-8cc2-05e3def6fade", "", context.GetTheme( ));
         AssignAttri("", false, edtavImagebanner_Internalname, AV7ImageBanner);
         AV13Imagebanner_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7f62b544-735a-4b44-8cc2-05e3def6fade", "", context.GetTheme( )));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            context.DoAjaxLoad(12, BannerRow);
         }
         AV7ImageBanner = context.GetImagePath( "7f62b544-735a-4b44-8cc2-05e3def6fade", "", context.GetTheme( ));
         AssignAttri("", false, edtavImagebanner_Internalname, AV7ImageBanner);
         AV13Imagebanner_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7f62b544-735a-4b44-8cc2-05e3def6fade", "", context.GetTheme( )));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            context.DoAjaxLoad(12, BannerRow);
         }
         /*  Sending Event outputs  */
      }

      private void E130P3( )
      {
         /* Gridhomemodulessdts_Load Routine */
         returnInSub = false;
         AV10GXV1 = 1;
         while ( AV10GXV1 <= AV5HomeModulesSDT.Count )
         {
            AV5HomeModulesSDT.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV5HomeModulesSDT.Item(AV10GXV1));
            lblOptionicon_Caption = StringUtil.Format( "<i class='HomeModulesBigIcon %1' style='font-size: 55px'></i>", ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optioniconthemeclass, "", "", "", "", "", "", "", "");
            AV6OptionLink = ((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)(AV5HomeModulesSDT.CurrentItem)).gxTpr_Optionwclink;
            AssignAttri("", false, edtavOptionlink_Internalname, AV6OptionLink);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 20;
            }
            sendrow_203( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_20_Refreshing )
            {
               context.DoAjaxLoad(20, GridhomemodulessdtsRow);
            }
            AV10GXV1 = (int)(AV10GXV1+1);
         }
         /*  Sending Event outputs  */
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
         PA0P2( ) ;
         WS0P2( ) ;
         WE0P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202191519155330", true, true);
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
            context.AddJavascriptSource("nosotros.js", "?202191519155330", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtavImagebanner_Internalname = "vIMAGEBANNER_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtavImagebanner_Internalname = "vIMAGEBANNER_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         SubsflControlProps_122( ) ;
         WB0P0( ) ;
         BannerRow = GXWebRow.GetNew(context,BannerContainer);
         if ( subBanner_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subBanner_Backstyle = 0;
            if ( StringUtil.StrCmp(subBanner_Class, "") != 0 )
            {
               subBanner_Linesclass = subBanner_Class+"Odd";
            }
         }
         else if ( subBanner_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subBanner_Backstyle = 0;
            subBanner_Backcolor = subBanner_Allbackcolor;
            if ( StringUtil.StrCmp(subBanner_Class, "") != 0 )
            {
               subBanner_Linesclass = subBanner_Class+"Uniform";
            }
         }
         else if ( subBanner_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subBanner_Backstyle = 1;
            if ( StringUtil.StrCmp(subBanner_Class, "") != 0 )
            {
               subBanner_Linesclass = subBanner_Class+"Odd";
            }
            subBanner_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subBanner_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subBanner_Backstyle = 1;
            if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
            {
               subBanner_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subBanner_Class, "") != 0 )
               {
                  subBanner_Linesclass = subBanner_Class+"Even";
               }
            }
            else
            {
               subBanner_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subBanner_Class, "") != 0 )
               {
                  subBanner_Linesclass = subBanner_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( BannerContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subBanner_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_12_idx+"\">") ;
         }
         /* Div Control */
         BannerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsbanner_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         /* Div Control */
         BannerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         /* Div Control */
         BannerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         /* Div Control */
         BannerRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         /* Attribute/Variable Label */
         BannerRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Image Banner",(string)"col-sm-3 AttributeBannerModulesLabel ObjectFitCoverLabel",(short)0,(bool)true,(string)""});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         /* Static Bitmap Variable */
         ClassString = "AttributeBannerModules ObjectFitCover";
         StyleString = "";
         AV7ImageBanner_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV7ImageBanner))&&String.IsNullOrEmpty(StringUtil.RTrim( AV13Imagebanner_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV7ImageBanner)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV7ImageBanner)) ? AV13Imagebanner_GXI : context.PathToRelativeUrl( AV7ImageBanner));
         BannerRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavImagebanner_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(int)edtavImagebanner_Enabled,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV7ImageBanner_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         BannerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         BannerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         BannerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         BannerRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         BannerColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         BannerRow.AddRenderProperties(BannerColumn);
         send_integrity_lvl_hashes0P2( ) ;
         /* End of Columns property logic. */
         BannerContainer.AddRow(BannerRow);
         nGXsfl_12_idx = ((subBanner_Islastpage==1)&&(nGXsfl_12_idx+1>subBanner_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         /* End function sendrow_122 */
      }

      protected void SubsflControlProps_203( )
      {
         lblOptionicon_Internalname = "OPTIONICON_"+sGXsfl_20_idx;
         edtavHomemodulessdt__optiontitle_Internalname = "HOMEMODULESSDT__OPTIONTITLE_"+sGXsfl_20_idx;
         edtavHomemodulessdt__optiondescription_Internalname = "HOMEMODULESSDT__OPTIONDESCRIPTION_"+sGXsfl_20_idx;
         edtavOptionlink_Internalname = "vOPTIONLINK_"+sGXsfl_20_idx;
      }

      protected void SubsflControlProps_fel_203( )
      {
         lblOptionicon_Internalname = "OPTIONICON_"+sGXsfl_20_fel_idx;
         edtavHomemodulessdt__optiontitle_Internalname = "HOMEMODULESSDT__OPTIONTITLE_"+sGXsfl_20_fel_idx;
         edtavHomemodulessdt__optiondescription_Internalname = "HOMEMODULESSDT__OPTIONDESCRIPTION_"+sGXsfl_20_fel_idx;
         edtavOptionlink_Internalname = "vOPTIONLINK_"+sGXsfl_20_fel_idx;
      }

      protected void sendrow_203( )
      {
         SubsflControlProps_203( ) ;
         WB0P0( ) ;
         GridhomemodulessdtsRow = GXWebRow.GetNew(context,GridhomemodulessdtsContainer);
         if ( subGridhomemodulessdts_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Odd";
            }
         }
         else if ( subGridhomemodulessdts_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 0;
            subGridhomemodulessdts_Backcolor = subGridhomemodulessdts_Allbackcolor;
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Uniform";
            }
         }
         else if ( subGridhomemodulessdts_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Odd";
            }
            subGridhomemodulessdts_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridhomemodulessdts_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridhomemodulessdts_Backstyle = 1;
            subGridhomemodulessdts_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subGridhomemodulessdts_Class, "") != 0 )
            {
               subGridhomemodulessdts_Linesclass = subGridhomemodulessdts_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsgridhomemodulessdts_Internalname+"_"+sGXsfl_20_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 HomeModulesBigIconCell",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Text block */
         GridhomemodulessdtsRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblOptionicon_Internalname,(string)lblOptionicon_Caption,(string)"",(string)"",(string)lblOptionicon_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 HomeModulesBigTitleCell",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Attribute/Variable Label */
         GridhomemodulessdtsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavHomemodulessdt__optiontitle_Internalname,(string)"Option Title",(string)"col-sm-3 AttributeHomeModulesBigTitleLabel",(short)0,(bool)true,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Single line edit */
         ROClassString = "AttributeHomeModulesBigTitle";
         GridhomemodulessdtsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavHomemodulessdt__optiontitle_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV5HomeModulesSDT.Item(AV10GXV1)).gxTpr_Optiontitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavHomemodulessdt__optiontitle_Jsonclick,(short)0,(string)"AttributeHomeModulesBigTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavHomemodulessdt__optiontitle_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 HomeModulesBigDescriptionCell",(string)"Center",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Attribute/Variable Label */
         GridhomemodulessdtsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavHomemodulessdt__optiondescription_Internalname,(string)"Option Description",(string)"col-sm-3 AttributeHomeModulesBigDescriptionLabel",(short)0,(bool)true,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Single line edit */
         ROClassString = "AttributeHomeModulesBigDescription";
         GridhomemodulessdtsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavHomemodulessdt__optiondescription_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem)AV5HomeModulesSDT.Item(AV10GXV1)).gxTpr_Optiondescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavHomemodulessdt__optiondescription_Jsonclick,(short)0,(string)"AttributeHomeModulesBigDescription",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavHomemodulessdt__optiondescription_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)20,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Center",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Table start */
         GridhomemodulessdtsRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgridhomemodulessdts_Internalname+"_"+sGXsfl_20_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Div Control */
         GridhomemodulessdtsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Attribute/Variable Label */
         GridhomemodulessdtsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavOptionlink_Internalname,(string)"Option Link",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GridhomemodulessdtsRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavOptionlink_Internalname,(string)AV6OptionLink,(string)"",(string)"",(short)0,(int)edtavOptionlink_Visible,(short)0,(short)0,(short)80,(string)"chr",(short)3,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"200",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("cell");
         }
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("row");
         }
         if ( GridhomemodulessdtsContainer.GetWrapped() == 1 )
         {
            GridhomemodulessdtsContainer.CloseTag("table");
         }
         /* End of table */
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         GridhomemodulessdtsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridhomemodulessdtsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridhomemodulessdtsRow.AddRenderProperties(GridhomemodulessdtsColumn);
         send_integrity_lvl_hashes0P3( ) ;
         /* End of Columns property logic. */
         GridhomemodulessdtsContainer.AddRow(GridhomemodulessdtsRow);
         nGXsfl_20_idx = ((subGridhomemodulessdts_Islastpage==1)&&(nGXsfl_20_idx+1>subGridhomemodulessdts_fnc_Recordsperpage( )) ? 1 : nGXsfl_20_idx+1);
         sGXsfl_20_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_20_idx), 4, 0), 4, "0");
         SubsflControlProps_203( ) ;
         /* End function sendrow_203 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavImagebanner_Internalname = "vIMAGEBANNER";
         divUnnamedtablefsbanner_Internalname = "UNNAMEDTABLEFSBANNER";
         lblOptionicon_Internalname = "OPTIONICON";
         edtavHomemodulessdt__optiontitle_Internalname = "HOMEMODULESSDT__OPTIONTITLE";
         edtavHomemodulessdt__optiondescription_Internalname = "HOMEMODULESSDT__OPTIONDESCRIPTION";
         edtavOptionlink_Internalname = "vOPTIONLINK";
         tblUnnamedtablecontentfsgridhomemodulessdts_Internalname = "UNNAMEDTABLECONTENTFSGRIDHOMEMODULESSDTS";
         divUnnamedtablefsgridhomemodulessdts_Internalname = "UNNAMEDTABLEFSGRIDHOMEMODULESSDTS";
         divTablecontent_Internalname = "TABLECONTENT";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subBanner_Internalname = "BANNER";
         subGridhomemodulessdts_Internalname = "GRIDHOMEMODULESSDTS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavHomemodulessdt__optiondescription_Jsonclick = "";
         edtavHomemodulessdt__optiontitle_Jsonclick = "";
         lblOptionicon_Caption = "<i class='HomeModulesBigIcon fa fa-home' style='font-size: 65px'></i>";
         edtavHomemodulessdt__optiondescription_Enabled = -1;
         edtavHomemodulessdt__optiontitle_Enabled = -1;
         subGridhomemodulessdts_Allowcollapsing = 0;
         edtavHomemodulessdt__optiondescription_Enabled = 0;
         edtavHomemodulessdt__optiontitle_Enabled = 0;
         lblOptionicon_Caption = "<i class='HomeModulesBigIcon fa fa-home' style='font-size: 65px'></i>";
         subGridhomemodulessdts_Backcolorstyle = 0;
         subBanner_Allowcollapsing = 0;
         edtavImagebanner_Enabled = 0;
         subBanner_Backcolorstyle = 0;
         subGridhomemodulessdts_Justifycontent = "center";
         subGridhomemodulessdts_Flexwrap = "wrap";
         subGridhomemodulessdts_Class = "FreeStyleHomeModulesBig";
         subBanner_Autoplay = StringUtil.Str( (decimal)(0), 1, 0);
         subBanner_Showarrows = StringUtil.LTrimStr( (decimal)(-1), 2, 0);
         subBanner_Class = "FreeStyleGrid";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Nosotros";
         edtavOptionlink_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'BANNER_nFirstRecordOnPage'},{av:'BANNER_nEOF'},{av:'GRIDHOMEMODULESSDTS_nFirstRecordOnPage'},{av:'GRIDHOMEMODULESSDTS_nEOF'},{av:'edtavOptionlink_Visible',ctrl:'vOPTIONLINK',prop:'Visible'},{av:'AV5HomeModulesSDT',fld:'vHOMEMODULESSDT',grid:20,pic:'',hsh:true},{av:'nRC_GXsfl_20',ctrl:'GRIDHOMEMODULESSDTS',prop:'GridRC'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("BANNER.LOAD","{handler:'E120P2',iparms:[]");
         setEventMetadata("BANNER.LOAD",",oparms:[{av:'AV7ImageBanner',fld:'vIMAGEBANNER',pic:''}]}");
         setEventMetadata("GRIDHOMEMODULESSDTS.LOAD","{handler:'E130P3',iparms:[{av:'AV5HomeModulesSDT',fld:'vHOMEMODULESSDT',grid:20,pic:'',hsh:true},{av:'GRIDHOMEMODULESSDTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_20',ctrl:'GRIDHOMEMODULESSDTS',prop:'GridRC'}]");
         setEventMetadata("GRIDHOMEMODULESSDTS.LOAD",",oparms:[{av:'lblOptionicon_Caption',ctrl:'OPTIONICON',prop:'Caption'},{av:'AV6OptionLink',fld:'vOPTIONLINK',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Imagebanner',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Optionlink',iparms:[]");
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
         AV5HomeModulesSDT = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem>( context, "HomeModulesSDTItem", "SsumarGroupDemo");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         BannerContainer = new GXWebGrid( context);
         sStyleString = "";
         subBanner_Header = "";
         BannerColumn = new GXWebColumn();
         AV7ImageBanner = "";
         GridhomemodulessdtsContainer = new GXWebGrid( context);
         subGridhomemodulessdts_Header = "";
         GridhomemodulessdtsColumn = new GXWebColumn();
         AV6OptionLink = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV13Imagebanner_GXI = "";
         BannerRow = new GXWebRow();
         GridhomemodulessdtsRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subBanner_Linesclass = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         subGridhomemodulessdts_Linesclass = "";
         lblOptionicon_Jsonclick = "";
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavHomemodulessdt__optiontitle_Enabled = 0;
         edtavHomemodulessdt__optiondescription_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subBanner_Backcolorstyle ;
      private short subBanner_Allowselection ;
      private short subBanner_Allowhovering ;
      private short subBanner_Allowcollapsing ;
      private short subBanner_Collapsed ;
      private short subGridhomemodulessdts_Backcolorstyle ;
      private short subGridhomemodulessdts_Allowselection ;
      private short subGridhomemodulessdts_Allowhovering ;
      private short subGridhomemodulessdts_Allowcollapsing ;
      private short subGridhomemodulessdts_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subBanner_Backstyle ;
      private short subGridhomemodulessdts_Backstyle ;
      private short BANNER_nEOF ;
      private short GRIDHOMEMODULESSDTS_nEOF ;
      private int nRC_GXsfl_12 ;
      private int nRC_GXsfl_20 ;
      private int nGXsfl_12_idx=1 ;
      private int nGXsfl_20_idx=1 ;
      private int edtavOptionlink_Visible ;
      private int edtavImagebanner_Enabled ;
      private int subBanner_Selectedindex ;
      private int subBanner_Selectioncolor ;
      private int subBanner_Hoveringcolor ;
      private int edtavHomemodulessdt__optiontitle_Enabled ;
      private int edtavHomemodulessdt__optiondescription_Enabled ;
      private int subGridhomemodulessdts_Selectedindex ;
      private int subGridhomemodulessdts_Selectioncolor ;
      private int subGridhomemodulessdts_Hoveringcolor ;
      private int AV10GXV1 ;
      private int subBanner_Islastpage ;
      private int subGridhomemodulessdts_Islastpage ;
      private int nGXsfl_20_fel_idx=1 ;
      private int idxLst ;
      private int subBanner_Backcolor ;
      private int subBanner_Allbackcolor ;
      private int subGridhomemodulessdts_Backcolor ;
      private int subGridhomemodulessdts_Allbackcolor ;
      private long BANNER_nCurrentRecord ;
      private long GRIDHOMEMODULESSDTS_nCurrentRecord ;
      private long BANNER_nFirstRecordOnPage ;
      private long GRIDHOMEMODULESSDTS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_12_idx="0001" ;
      private string sGXsfl_20_idx="0001" ;
      private string edtavOptionlink_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string subBanner_Class ;
      private string subBanner_Showarrows ;
      private string subBanner_Autoplay ;
      private string subGridhomemodulessdts_Class ;
      private string subGridhomemodulessdts_Flexwrap ;
      private string subGridhomemodulessdts_Justifycontent ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string sStyleString ;
      private string subBanner_Internalname ;
      private string subBanner_Header ;
      private string subGridhomemodulessdts_Internalname ;
      private string subGridhomemodulessdts_Header ;
      private string lblOptionicon_Caption ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavImagebanner_Internalname ;
      private string edtavHomemodulessdt__optiontitle_Internalname ;
      private string edtavHomemodulessdt__optiondescription_Internalname ;
      private string sGXsfl_20_fel_idx="0001" ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subBanner_Linesclass ;
      private string divUnnamedtablefsbanner_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string lblOptionicon_Internalname ;
      private string subGridhomemodulessdts_Linesclass ;
      private string divUnnamedtablefsgridhomemodulessdts_Internalname ;
      private string lblOptionicon_Jsonclick ;
      private string ROClassString ;
      private string edtavHomemodulessdt__optiontitle_Jsonclick ;
      private string edtavHomemodulessdt__optiondescription_Jsonclick ;
      private string tblUnnamedtablecontentfsgridhomemodulessdts_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_20_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV7ImageBanner_IsBlob ;
      private string AV6OptionLink ;
      private string AV13Imagebanner_GXI ;
      private string AV7ImageBanner ;
      private GXWebGrid BannerContainer ;
      private GXWebGrid GridhomemodulessdtsContainer ;
      private GXWebRow BannerRow ;
      private GXWebRow GridhomemodulessdtsRow ;
      private GXWebColumn BannerColumn ;
      private GXWebColumn GridhomemodulessdtsColumn ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeModulesSDT_HomeModulesSDTItem> AV5HomeModulesSDT ;
      private GXWebForm Form ;
   }

}
