package com.example.miprimerproyecto;

import android.os.Build;
import android.os.Bundle;
import android.text.Html;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.google.android.material.textfield.TextInputEditText;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;

public class Prueba extends AppCompatActivity {
    private TextInputEditText txtCliente;
    private TextView txtListado;

    @RequiresApi(api = Build.VERSION_CODES.Q)
    @Override
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.prueba);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.Layout), (v, insets) ->{
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);

            return insets;
        });
        this.txtListado=findViewById(R.id.listadoClientesText);
        this.txtCliente=findViewById(R.id.textInput);

        Button guardarBoton = findViewById(R.id.guardarButton);
        Button verClientes = findViewById(R.id.verClientesButton);

        guardarBoton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // Do something in response to button click
                Guardar(view);
            }
        });

        verClientes.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Leer(view);
            }
        });
    }

    public void Guardar(View vista){
        String texto = txtCliente.getText().toString();
        FileOutputStream file=null;

        try{
            file=openFileOutput("texto.txt",MODE_APPEND);
            file.write((texto + "\n").getBytes());
            Log.d("tag1", String.valueOf(getFilesDir()));
        } catch (IOException e) {
            e.printStackTrace();
        }finally {
            if(file!=null){try {
                file.close();
            } catch (IOException ex) {
                ex.printStackTrace();
            }
            }
        }
    }

    public void Leer(View vista){
        FileInputStream file = null;
        try {
            file=openFileInput("texto.txt");
            InputStreamReader Leerfile = new InputStreamReader(file);
            BufferedReader bufferLeer = new BufferedReader(Leerfile);
            String linea;
            String parrafo = "";
            linea=bufferLeer.readLine();
            while ((linea!=null)){
                parrafo +=  linea.toString() + "\n";
                System.out.println(linea.toString());
                linea=bufferLeer.readLine();
            }
            txtListado.setText(parrafo);
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }finally {
            if (file!=null){
                try {
                    file.close();
                } catch (IOException e) {
                    System.out.println(e.getMessage());
                }
            }
        }
    }
}