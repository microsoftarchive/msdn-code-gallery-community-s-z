//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//// PARTICULAR PURPOSE. 
//// 
//// Copyright (c) Microsoft Corporation. All rights reserved     
////
//// To see the topic that inspired this sample app, go to http://msdn.microsoft.com/en-us/library/windows/apps/dn163531

(function () {
    "use strict";

    // Defines a years worth of data to initialize the various charts
    // and graphs with. In a real-world scenario this data would be
    // provided by a remote webservice.
    WinJS.Namespace.define('Data', {

        Static: {

            "footTraffic": {
                "data": {
                    "hourly": [
                       {
                           "date": new Date("2012-12-30T20:00:00.000Z"),
                           "values": [
                        {
                            "value": 740
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-30T21:00:00.000Z"),
                           "values": [
                        {
                            "value": 663
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-30T22:00:00.000Z"),
                           "values": [
                        {
                            "value": 557
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-30T23:00:00.000Z"),
                           "values": [
                        {
                            "value": 894
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T00:00:00.000Z"),
                           "values": [
                        {
                            "value": 628
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T01:00:00.000Z"),
                           "values": [
                        {
                            "value": 525
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T02:00:00.000Z"),
                           "values": [
                        {
                            "value": 617
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T03:00:00.000Z"),
                           "values": [
                        {
                            "value": 425
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T04:00:00.000Z"),
                           "values": [
                        {
                            "value": 420
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T05:00:00.000Z"),
                           "values": [
                        {
                            "value": 225
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T06:00:00.000Z"),
                           "values": [
                        {
                            "value": 347
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 329
                        }
                           ],
                           "ct": 0
                       }
                    ],
                    "daily": [
                       {
                           "date": new Date("2012-12-24T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 12139
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-25T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 11492
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-26T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 12196
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-27T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 11438
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-28T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 11738
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-29T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 11741
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-30T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 11387
                        }
                           ],
                           "ct": 23
                       }
                    ],
                    "weekly": [
                       {
                           "date": new Date("2012-10-09T00:00:00.000Z"),
                           "values": [
                        {
                            "value": 81208
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-10-16T01:00:00.000Z"),
                           "values": [
                        {
                            "value": 83123
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-10-23T02:00:00.000Z"),
                           "values": [
                        {
                            "value": 81419
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-10-30T03:00:00.000Z"),
                           "values": [
                        {
                            "value": 82326
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-06T04:00:00.000Z"),
                           "values": [
                        {
                            "value": 82944
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-13T05:00:00.000Z"),
                           "values": [
                        {
                            "value": 81544
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-20T06:00:00.000Z"),
                           "values": [
                        {
                            "value": 80373
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-27T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 79883
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-04T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 81763
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-11T09:00:00.000Z"),
                           "values": [
                        {
                            "value": 80153
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-18T10:00:00.000Z"),
                           "values": [
                        {
                            "value": 81592
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-25T11:00:00.000Z"),
                           "values": [
                        {
                            "value": 69167
                        }
                           ],
                           "ct": 140
                       }
                    ],
                    "monthly": [
                       {
                           "date": new Date("2012-01-01T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 365680
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-02-01T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 336323
                        }
                           ],
                           "ct": 695
                       },
                       {
                           "date": new Date("2012-03-01T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 362861
                        }
                           ],
                           "ct": 742
                       },
                       {
                           "date": new Date("2012-04-01T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 353937
                        }
                           ],
                           "ct": 719
                       },
                       {
                           "date": new Date("2012-05-01T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 359157
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-06-01T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 355678
                        }
                           ],
                           "ct": 719
                       },
                       {
                           "date": new Date("2012-07-01T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 366838
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-08-01T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 361394
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-09-01T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 358952
                        }
                           ],
                           "ct": 719
                       },
                       {
                           "date": new Date("2012-10-01T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 359296
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-11-01T07:00:00.000Z"),
                           "values": [
                        {
                            "value": 349361
                        }
                           ],
                           "ct": 720
                       },
                       {
                           "date": new Date("2012-12-01T08:00:00.000Z"),
                           "values": [
                        {
                            "value": 346221
                        }
                           ],
                           "ct": 719
                       }
                    ]
                },
                "templates": [
                   {
                       "value": 500
                   }
                ]
            },
            "revenue": {
                "data": {
                    "hourly": [
                       {
                           "date": new Date("2012-12-30T20:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 7262
                        },
                        {
                            "label": "gross",
                            "value": 17761
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-30T21:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 7320
                        },
                        {
                            "label": "gross",
                            "value": 12530
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-30T22:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 9282
                        },
                        {
                            "label": "gross",
                            "value": 15928
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-30T23:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 10080
                        },
                        {
                            "label": "gross",
                            "value": 10521
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T00:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 8215
                        },
                        {
                            "label": "gross",
                            "value": 18365
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T01:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 6284
                        },
                        {
                            "label": "gross",
                            "value": 9877
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T02:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 7538
                        },
                        {
                            "label": "gross",
                            "value": 9167
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T03:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 5337
                        },
                        {
                            "label": "gross",
                            "value": 5627
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T04:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 3789
                        },
                        {
                            "label": "gross",
                            "value": 5592
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T05:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4929
                        },
                        {
                            "label": "gross",
                            "value": 6865
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T06:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 2878
                        },
                        {
                            "label": "gross",
                            "value": 6504
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 1996
                        },
                        {
                            "label": "gross",
                            "value": 4508
                        }
                           ],
                           "ct": 0
                       }
                    ],
                    "daily": [
                       {
                           "date": new Date("2012-12-24T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 145975
                        },
                        {
                            "label": "gross",
                            "value": 246806
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-25T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 142201
                        },
                        {
                            "label": "gross",
                            "value": 247588
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-26T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 135234
                        },
                        {
                            "label": "gross",
                            "value": 244270
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-27T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 152640
                        },
                        {
                            "label": "gross",
                            "value": 255380
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-28T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 147913
                        },
                        {
                            "label": "gross",
                            "value": 224547
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-29T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 138192
                        },
                        {
                            "label": "gross",
                            "value": 243924
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-30T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 148768
                        },
                        {
                            "label": "gross",
                            "value": 242135
                        }
                           ],
                           "ct": 23
                       }
                    ],
                    "weekly": [
                       {
                           "date": new Date("2012-10-09T00:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 1009394
                        },
                        {
                            "label": "gross",
                            "value": 1676643
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-10-16T01:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 979400
                        },
                        {
                            "label": "gross",
                            "value": 1665761
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-10-23T02:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 996716
                        },
                        {
                            "label": "gross",
                            "value": 1644488
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-10-30T03:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 986469
                        },
                        {
                            "label": "gross",
                            "value": 1625353
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-06T04:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 986792
                        },
                        {
                            "label": "gross",
                            "value": 1658780
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-13T05:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 979465
                        },
                        {
                            "label": "gross",
                            "value": 1637566
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-20T06:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 995620
                        },
                        {
                            "label": "gross",
                            "value": 1707774
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-27T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 978191
                        },
                        {
                            "label": "gross",
                            "value": 1603520
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-04T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 977552
                        },
                        {
                            "label": "gross",
                            "value": 1653487
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-11T09:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 988583
                        },
                        {
                            "label": "gross",
                            "value": 1724397
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-18T10:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 1013329
                        },
                        {
                            "label": "gross",
                            "value": 1665077
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-25T11:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 855120
                        },
                        {
                            "label": "gross",
                            "value": 1442662
                        }
                           ],
                           "ct": 140
                       }
                    ],
                    "monthly": [
                       {
                           "date": new Date("2012-01-01T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4387212
                        },
                        {
                            "label": "gross",
                            "value": 7300204
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-02-01T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4133589
                        },
                        {
                            "label": "gross",
                            "value": 6818207
                        }
                           ],
                           "ct": 695
                       },
                       {
                           "date": new Date("2012-03-01T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4375879
                        },
                        {
                            "label": "gross",
                            "value": 7345113
                        }
                           ],
                           "ct": 742
                       },
                       {
                           "date": new Date("2012-04-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4247395
                        },
                        {
                            "label": "gross",
                            "value": 7035842
                        }
                           ],
                           "ct": 719
                       },
                       {
                           "date": new Date("2012-05-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4331060
                        },
                        {
                            "label": "gross",
                            "value": 7259841
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-06-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4161112
                        },
                        {
                            "label": "gross",
                            "value": 7106975
                        }
                           ],
                           "ct": 719
                       },
                       {
                           "date": new Date("2012-07-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4381240
                        },
                        {
                            "label": "gross",
                            "value": 7229997
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-08-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4475986
                        },
                        {
                            "label": "gross",
                            "value": 7219112
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-09-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4230619
                        },
                        {
                            "label": "gross",
                            "value": 7038813
                        }
                           ],
                           "ct": 719
                       },
                       {
                           "date": new Date("2012-10-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4407566
                        },
                        {
                            "label": "gross",
                            "value": 7236091
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-11-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4224130
                        },
                        {
                            "label": "gross",
                            "value": 7071763
                        }
                           ],
                           "ct": 720
                       },
                       {
                           "date": new Date("2012-12-01T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "net",
                            "value": 4240549
                        },
                        {
                            "label": "gross",
                            "value": 7176463
                        }
                           ],
                           "ct": 719
                       }
                    ]
                },
                "templates": [
                   {
                       "label": "net",
                       "value": 6000
                   },
                   {
                       "label": "gross",
                       "value": 10000
                   }
                ]
            },
            "promotions": {
                "data": {
                    "hourly": [
                       {
                           "date": new Date("2012-12-30T20:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 31757
                        },
                        {
                            "label": "promotions",
                            "value": 16821
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-30T21:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 24354
                        },
                        {
                            "label": "promotions",
                            "value": 18578
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-30T22:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 34778
                        },
                        {
                            "label": "promotions",
                            "value": 12954
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-30T23:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 23098
                        },
                        {
                            "label": "promotions",
                            "value": 15586
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T00:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 26292
                        },
                        {
                            "label": "promotions",
                            "value": 10484
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T01:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 17107
                        },
                        {
                            "label": "promotions",
                            "value": 11558
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T02:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 16722
                        },
                        {
                            "label": "promotions",
                            "value": 10711
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T03:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 17095
                        },
                        {
                            "label": "promotions",
                            "value": 8982
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T04:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14308
                        },
                        {
                            "label": "promotions",
                            "value": 8588
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T05:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 16573
                        },
                        {
                            "label": "promotions",
                            "value": 4201
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T06:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 7706
                        },
                        {
                            "label": "promotions",
                            "value": 6340
                        }
                           ],
                           "ct": 0
                       },
                       {
                           "date": new Date("2012-12-31T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 13625
                        },
                        {
                            "label": "promotions",
                            "value": 4636
                        }
                           ],
                           "ct": 0
                       }
                    ],
                    "daily": [
                       {
                           "date": new Date("2012-12-24T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 471347
                        },
                        {
                            "label": "promotions",
                            "value": 231608
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-25T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 474212
                        },
                        {
                            "label": "promotions",
                            "value": 232566
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-26T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 489507
                        },
                        {
                            "label": "promotions",
                            "value": 254905
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-27T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 477083
                        },
                        {
                            "label": "promotions",
                            "value": 242896
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-28T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 480294
                        },
                        {
                            "label": "promotions",
                            "value": 225391
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-29T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 443581
                        },
                        {
                            "label": "promotions",
                            "value": 250962
                        }
                           ],
                           "ct": 23
                       },
                       {
                           "date": new Date("2012-12-30T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 477879
                        },
                        {
                            "label": "promotions",
                            "value": 229028
                        }
                           ],
                           "ct": 23
                       }
                    ],
                    "weekly": [
                       {
                           "date": new Date("2012-10-09T00:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3343444
                        },
                        {
                            "label": "promotions",
                            "value": 1621422
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-10-16T01:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3237694
                        },
                        {
                            "label": "promotions",
                            "value": 1667470
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-10-23T02:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3200556
                        },
                        {
                            "label": "promotions",
                            "value": 1637171
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-10-30T03:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3274474
                        },
                        {
                            "label": "promotions",
                            "value": 1679631
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-06T04:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3379634
                        },
                        {
                            "label": "promotions",
                            "value": 1653227
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-13T05:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3291735
                        },
                        {
                            "label": "promotions",
                            "value": 1636224
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-20T06:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3174692
                        },
                        {
                            "label": "promotions",
                            "value": 1642783
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-11-27T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3341019
                        },
                        {
                            "label": "promotions",
                            "value": 1646347
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-04T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3350517
                        },
                        {
                            "label": "promotions",
                            "value": 1646257
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-11T09:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3186023
                        },
                        {
                            "label": "promotions",
                            "value": 1627842
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-18T10:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 3267549
                        },
                        {
                            "label": "promotions",
                            "value": 1692624
                        }
                           ],
                           "ct": 168
                       },
                       {
                           "date": new Date("2012-12-25T11:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 2815598
                        },
                        {
                            "label": "promotions",
                            "value": 1417381
                        }
                           ],
                           "ct": 140
                       }
                    ],
                    "monthly": [
                       {
                           "date": new Date("2012-01-01T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14670698
                        },
                        {
                            "label": "promotions",
                            "value": 7318007
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-02-01T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 13562805
                        },
                        {
                            "label": "promotions",
                            "value": 6876177
                        }
                           ],
                           "ct": 695
                       },
                       {
                           "date": new Date("2012-03-01T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14732543
                        },
                        {
                            "label": "promotions",
                            "value": 7312667
                        }
                           ],
                           "ct": 742
                       },
                       {
                           "date": new Date("2012-04-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14321299
                        },
                        {
                            "label": "promotions",
                            "value": 6968249
                        }
                           ],
                           "ct": 719
                       },
                       {
                           "date": new Date("2012-05-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14600328
                        },
                        {
                            "label": "promotions",
                            "value": 7268557
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-06-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14051180
                        },
                        {
                            "label": "promotions",
                            "value": 7042374
                        }
                           ],
                           "ct": 719
                       },
                       {
                           "date": new Date("2012-07-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14753696
                        },
                        {
                            "label": "promotions",
                            "value": 7374468
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-08-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14428797
                        },
                        {
                            "label": "promotions",
                            "value": 7347848
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-09-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14301291
                        },
                        {
                            "label": "promotions",
                            "value": 7030047
                        }
                           ],
                           "ct": 719
                       },
                       {
                           "date": new Date("2012-10-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14457535
                        },
                        {
                            "label": "promotions",
                            "value": 7254729
                        }
                           ],
                           "ct": 743
                       },
                       {
                           "date": new Date("2012-11-01T07:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 14107581
                        },
                        {
                            "label": "promotions",
                            "value": 7043478
                        }
                           ],
                           "ct": 720
                       },
                       {
                           "date": new Date("2012-12-01T08:00:00.000Z"),
                           "values": [
                        {
                            "label": "sales",
                            "value": 13981391
                        },
                        {
                            "label": "promotions",
                            "value": 7099604
                        }
                           ],
                           "ct": 719
                       }
                    ]
                },
                "templates": [
                   {
                       "label": "sales",
                       "value": 20000
                   },
                   {
                       "label": "promotions",
                       "value": 10000
                   }
                ]
            },
        }
    });

}());