using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class menuoptionsdata : GXProcedure
   {
      public menuoptionsdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public menuoptionsdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "SsumarGroupDemo") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol )
      {
         menuoptionsdata objmenuoptionsdata;
         objmenuoptionsdata = new menuoptionsdata();
         objmenuoptionsdata.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "SsumarGroupDemo") ;
         objmenuoptionsdata.context.SetSubmitInitialConfig(context);
         objmenuoptionsdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmenuoptionsdata);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((menuoptionsdata)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV5id = 0;
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wwpbaseobjects.home.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Inicio";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wwpbaseobjects.nosotros.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Nosotros";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wwpbaseobjects.servicios.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Servicios";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wwpbaseobjects.noticias.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Noticias";
         Gxm1dvelop_menu.gxTpr_Authorizationkey = "";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
         AV5id = (short)(AV5id+1);
         Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(AV5id), 4, 0);
         Gxm1dvelop_menu.gxTpr_Tooltip = "";
         Gxm1dvelop_menu.gxTpr_Link = formatLink("wwpbaseobjects.contacto.aspx") ;
         Gxm1dvelop_menu.gxTpr_Linktarget = "";
         Gxm1dvelop_menu.gxTpr_Iconclass = "";
         Gxm1dvelop_menu.gxTpr_Caption = "Contacto";
         Gxm1dvelop_menu.gxTpr_Authorizationkey = "";
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV5id ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm1dvelop_menu ;
   }

}
