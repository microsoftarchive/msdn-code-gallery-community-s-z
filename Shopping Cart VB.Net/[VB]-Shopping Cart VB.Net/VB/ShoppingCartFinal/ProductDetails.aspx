<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProductDetails.aspx.vb" Inherits="ShoppingCartFinal.ProductDetails" %>
<%@ Register src="Controls/AlsoPurchased.ascx" tagname="AlsoPurchased" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:FormView ID="FormView_Product" runat="server" DataKeyNames="ProductID" 
        DataSourceID="EDS_Product" 
        >
        <ItemTemplate>
        <div class="ContentHead"><%# Eval("ModelName") %></div><br />
        <table  border="0">
        <tr>
            <td style="vertical-align: top;">
             <img src='Catalog/Images/<%# Eval("ProductImage") %>'  border="0" alt='<%# Eval("ModelName") %>' />
            </td>
            <td style="vertical-align: top"><%# Eval("Description") %><br /><br /><br />
                <uc1:AlsoPurchased ID="AlsoPurchased1" runat="server" ProductId='<%# Eval("ProductID") %>' />   
            </td>
        </tr>
        </table>
        <span class="UnitCost"><b>Your Price:</b>&nbsp;<%# Eval("UnitCost", "{0:c}")%></span><br /><span class="ModelNumber"><b>Model Number:</b>&nbsp;<%# Eval("ModelNumber") %></span><br />
        <a href='AddToCart.aspx?ProductID=<%# Eval("ProductID") %>' style="border: 0 none white"><img id="Img1" src="~/Styles/Images/add_to_cart.gif" runat="server" alt="" style="border-width: 0" /></a><br />
        <br /><div class="SubContentHead">Reviews</div><br />
        <a id="ReviewList_AddReview" href="ReviewAdd.aspx?productID=<%# Eval("ProductID") %>">
           <img id="Img2" runat="server" style="vertical-align: bottom" src="~/Styles/Images/review_this_product.gif" alt="" />
        </a>       
        </ItemTemplate>
    </asp:FormView>
    <asp:EntityDataSource ID="EDS_Product" runat="server" AutoGenerateWhereClause="True"  EnableFlattening="False" 
                          ConnectionString="name=CommerceEntities" 
                          DefaultContainerName="CommerceEntities" 
                          EntitySetName="Products" 
                          EntityTypeFilter="" 
                          Select="" Where="">
                          <WhereParameters>
                                <asp:QueryStringParameter Name="ProductID" QueryStringField="productID"  Type="Int32" />
                          </WhereParameters>
    </asp:EntityDataSource>
    <asp:ListView ID="ListView_Comments" runat="server" DataKeyNames="ReviewID,ProductID,Rating" DataSourceID="EDS_CommentsList">
        <ItemTemplate>
            <tr style="background-color:#EDECB3;color: #000000;">
                <td><%# Eval("CustomerName") %></td>
                <td><img src='Styles/Images/ReviewRating_d<%# Eval("Rating") %>.gif' alt=""><br /></td>
                <td><%# Eval("Comments") %></td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color:#F8F8F8;">
                <td><%# Eval("CustomerName") %></td>
                <td><img src='Styles/Images/ReviewRating_da<%# Eval("Rating") %>.gif' alt=""><br /></td>
                <td><%# Eval("Comments") %></td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table id="Table1" runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr><td>There are no reviews yet for this product.</td></tr>
            </table>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <table id="Table2" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="Tr2" runat="server" style="background-color:#DCDCDC;color: #000000;">
                                <th id="Th1" runat="server">Customer</th>
                                <th id="Th2" runat="server">Rating</th>
                                <th id="Th3" runat="server">Comments</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server"></tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields><asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" /></Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    <asp:EntityDataSource ID="EDS_CommentsList" runat="server"  EnableFlattening="False" AutoGenerateWhereClause="True" EntityTypeFilter="" Select="" Where=""
                          ConnectionString="name=CommerceEntities" 
                          DefaultContainerName="CommerceEntities" 
                          EntitySetName="Reviews">
                          <WhereParameters>
                             <asp:QueryStringParameter Name="ProductID" QueryStringField="productID"  Type="Int32" />
                          </WhereParameters>
    </asp:EntityDataSource>

</asp:Content>
