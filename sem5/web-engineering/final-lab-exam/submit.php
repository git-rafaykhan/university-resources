<!DOCTYPE html>
<html>
<head>
    <title>Student Details</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #eef2f3;
        }

        .output {
            width: 400px;
            margin: 100px auto;
            padding: 20px;
            background-color: white;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        h2 {
            text-align: center;
        }
    </style>
</head>

<body>

<div class="output">
    <h2>Submitted Student Information</h2>

    <?php
        $name = htmlspecialchars($_POST['name']);
        $email = htmlspecialchars($_POST['email']);
        $age = htmlspecialchars($_POST['age']);

        echo "<p><strong>Name:</strong> $name</p>";
        echo "<p><strong>Email:</strong> $email</p>";
        echo "<p><strong>Age:</strong> $age</p>";
    ?>
</div>

</body>
</html>
