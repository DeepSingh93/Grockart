<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("default", "", "~/Default_home.aspx");
        routes.MapPageRoute("product-page", "Products", "~/Products.aspx");
        routes.MapPageRoute("signout-page", "signout", "~/signout.aspx");
        routes.MapPageRoute("login-page", "login", "~/Login.aspx");
        routes.MapPageRoute("admin-page", "admin", "~/Admin.aspx");
        routes.MapPageRoute("admin-category", "admin-category", "~/Admin_category.aspx");
        routes.MapPageRoute("admin-store", "admin-store", "~/Admin_store.aspx");
        routes.MapPageRoute("admin-product", "admin-product", "~/Admin_product.aspx");
        routes.MapPageRoute("admin-product-by-store", "admin-product-by-store", "~/Admin_product_by_store.aspx");
        routes.MapPageRoute("admin-orders", "admin-orders", "~/Admin_orders.aspx");
        routes.MapPageRoute("internal-redirect-page", "InternalRedirect", "~/InternalRedirect.aspx");
        routes.MapPageRoute("Cart", "Cart", "~/Cart.aspx");
        routes.MapPageRoute("Register", "Register", "~/Register.aspx");
        routes.MapPageRoute("products-page", "Products/{ProductID}", "~/ParticularProduct.aspx");
        routes.MapPageRoute("admin-settings", "admin-settings", "~/Admin_Settings.aspx");
        routes.MapPageRoute("my-orders", "orders", "~/MyOrders.aspx");
        routes.MapPageRoute("checkout", "checkout", "~/Checkout.aspx");
        routes.MapPageRoute("my-orders-details", "orders/{orderID}", "~/ViewOrderDetails.aspx");
        routes.MapPageRoute("login-sigin", "Signin", "~/Login.aspx");
    }
</script>
