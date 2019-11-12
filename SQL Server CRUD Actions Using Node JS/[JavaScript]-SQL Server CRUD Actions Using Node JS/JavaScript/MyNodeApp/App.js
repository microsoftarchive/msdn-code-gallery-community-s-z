//MSSQL Instance Creation
var sqlInstance = require("mssql");

//Database configuration
var setUp = {
    server: 'localhost',
    database: 'TrialDB',
    user: 'sa',
    password: 'sa',
    port: 1433
};

function executeDatabaseActions() {
    try {
        sqlInstance.connect(setUp)
            .then(function () {

                // To retrieve all the data - Start
                new sqlInstance.Request()
                    .query("select * from Course")
                    .then(function (dbData) {
                        if (dbData == null || dbData.length === 0)
                            return;
                        console.dir('All the courses');
                        console.dir(dbData);
                    })
                    .catch(function (error) {
                        console.dir(error);
                    });

                // To retrieve all the data - End

                // To retrieve specicfic data - Start
                var value = 2;
                new sqlInstance.Request()
                    .input("param", sqlInstance.Int, value)
                    .query("select * from Course where CourseID = @param")
                    .then(function (dbData) {
                        if (dbData == null || dbData.length === 0)
                            return;
                        console.dir('Course with ID = 2');
                        console.dir(dbData);
                    })
                    .catch(function (error) {
                        console.dir(error);
                    });
                // To retrieve specicfic data - End

                // Insert data - Start
                var dbConn = new sqlInstance.Connection(setUp,
                    function (err) {
                        var myTransaction = new sqlInstance.Transaction(dbConn);
                        myTransaction.begin(function (error) {
                            var rollBack = false;
                            myTransaction.on('rollback',
                                function (aborted) {
                                    rollBack = true;
                                });
                            new sqlInstance.Request(myTransaction)
                                .query("INSERT INTO [dbo].[Course] ([CourseName],[CourseDescription]) VALUES ('Node js', 'Learn Node JS in 7 days')",
                                function (err, recordset) {
                                    if (err) {
                                        if (!rollBack) {
                                            myTransaction.rollback(function (err) {
                                                console.dir(err);
                                            });
                                        }
                                    } else {
                                        myTransaction.commit().then(function (recordset) {
                                            console.dir('Data is inserted successfully!');
                                        }).catch(function (err) {
                                            console.dir('Error in transaction commit ' + err);
                                        });
                                    }
                                });
                        });
                    });
                // Insert data - End

                // Delete data - Start
                var delValue = 4;
                var dbConn = new sqlInstance.Connection(setUp,
                    function (err) {
                        var myTransaction = new sqlInstance.Transaction(dbConn);
                        myTransaction.begin(function (error) {
                            var rollBack = false;
                            myTransaction.on('rollback',
                                function (aborted) {
                                    rollBack = true;
                                });
                            new sqlInstance.Request(myTransaction)
                                .query("DELETE FROM [dbo].[Course] WHERE CourseID=" + delValue,
                                function (err, recordset) {
                                    if (err) {
                                        if (!rollBack) {
                                            myTransaction.rollback(function (err) {
                                                console.dir(err);
                                            });
                                        }
                                    } else {
                                        myTransaction.commit().then(function (recordset) {
                                            console.dir('Data is deleted successfully!');
                                        }).catch(function (err) {
                                            console.dir('Error in transaction commit ' + err);
                                        });
                                    }
                                });
                        });
                    });
                // Delete data - End

                // Update data - Start
                var updValue = 3;
                var dbConn = new sqlInstance.Connection(setUp,
                    function (err) {
                        var myTransaction = new sqlInstance.Transaction(dbConn);
                        myTransaction.begin(function (error) {
                            var rollBack = false;
                            myTransaction.on('rollback',
                                function (aborted) {
                                    rollBack = true;
                                });
                            new sqlInstance.Request(myTransaction)
                                .query("UPDATE [dbo].[Course] SET [CourseName] = 'Test' WHERE CourseID=" + updValue,
                                function (err, recordset) {
                                    if (err) {
                                        if (!rollBack) {
                                            myTransaction.rollback(function (err) {
                                                console.dir(err);
                                            });
                                        }
                                    } else {
                                        myTransaction.commit().then(function (recordset) {
                                            console.dir('Data is updated successfully!');
                                        }).catch(function (err) {
                                            console.dir('Error in transaction commit ' + err);
                                        });
                                    }
                                });
                        });
                    });
                // Update data - End


            }).catch(function (error) {
                console.dir(error);
            });
    } catch (error) {
        console.dir(error);
    }
}
executeDatabaseActions();