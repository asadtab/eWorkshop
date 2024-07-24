import 'package:commons/models/user.dart';
import 'package:flutter/material.dart';

class UserScreen extends StatelessWidget {
  const UserScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('User Profile'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            CircleAvatar(
              radius: 60,
            ),
            SizedBox(height: 20),
            Text(
              User.name ?? "",
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            Text(
              User.username ?? "",
              style: TextStyle(fontSize: 16, color: Colors.grey),
            ),
            SizedBox(height: 20),
            ListTile(
              leading: Icon(Icons.work),
              title: Text(User.roles.join(", ")),
              onTap: () {},
            ),
            ListTile(
              leading: Icon(Icons.email),
              title: Text(User.email ?? ""),
              onTap: () {},
            ),
          ],
        ),
      ),
    );
  }
}
