import 'package:flutter/material.dart';

class NotificationBadgeIcon extends StatelessWidget {
  final IconData icon;
  final int count;
  final Color badgeColor;
  final Color iconColor;
  final double iconSize;
  final VoidCallback? onTap;

  const NotificationBadgeIcon({
    super.key,
    required this.icon,
    required this.count,
    this.badgeColor = Colors.red,
    this.iconColor = Colors.black,
    this.iconSize = 28,
    this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Stack(
        clipBehavior: Clip.none,
        children: [
          Icon(icon, size: iconSize, color: iconColor),
          if (count > 0)
            Positioned(
              right: -6,
              top: -6,
              child: Container(
                padding: const EdgeInsets.all(3),
                constraints: const BoxConstraints(
                  minWidth: 18,
                  minHeight: 18,
                ),
                decoration: BoxDecoration(
                  color: badgeColor,
                  shape: count > 99 ? BoxShape.rectangle : BoxShape.circle,
                  borderRadius: count > 99
                      ? BorderRadius.circular(9)
                      : null,
                ),
                child: Text(
                  count > 99 ? '99+' : count.toString(),
                  style: const TextStyle(
                    color: Colors.white,
                    fontSize: 10,
                    fontWeight: FontWeight.bold,
                    height: 1,
                  ),
                  textAlign: TextAlign.center,
                ),
              ),
            ),
        ],
      ),
    );
  }
}