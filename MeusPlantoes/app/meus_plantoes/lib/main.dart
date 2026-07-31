import 'package:flutter/material.dart';

import 'models/tipo_plantao.dart';

void main() {
  runApp(const MeusPlantoesApp());
}

class MeusPlantoesApp extends StatelessWidget {
  const MeusPlantoesApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Meus Plantões',
      debugShowCheckedModeBanner: false,
      home: const HomeScreen(),
    );
  }
}

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Meus Plantões'),
      ),
      body: Center(
        child: Text(
          TipoPlantao.noturno.name,
          style: const TextStyle(
            fontSize: 24,
          ),
        ),
      ),
    );
  }
}