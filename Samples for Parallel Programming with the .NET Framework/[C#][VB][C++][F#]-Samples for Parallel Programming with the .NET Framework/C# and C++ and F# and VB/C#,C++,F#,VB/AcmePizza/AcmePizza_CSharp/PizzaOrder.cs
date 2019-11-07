//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: PizzaOrder.cs
//
//--------------------------------------------------------------------------

namespace AcmePizza
{
    public enum PizzaToppings
    {
        Mushrooms,
        Olives,
        Sausage,
        Pepperoni,
        Cheese,
        Onions,
        BellPeppers,
        Bacon,
        Chicken,
        Artichokes,
    }

    public enum OrderSource
    {
        Phone,
        Internet,
        WalkIn,
        Fax,
    }

    public struct PizzaOrder
    {
        public OrderSource Source {get;set; }
        public string PhoneNumber { get; set; }
        public int Size { get; set; }
        public bool IsDelivery { get; set; }
        public PizzaToppings[] Toppings { get; set; }
    }
}
