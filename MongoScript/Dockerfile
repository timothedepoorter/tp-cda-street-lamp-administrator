FROM mongo:latest

COPY Lampe.Capteur.json /Lampe.Capteur.json

COPY Lampe.Horaire.json /Lampe.Horaire.json

COPY Lampe.Lampadaire.json /Lampe.Lampadaire.json

COPY Lampe.Utilisateur.json /Lampe.Utilisateur.json

CMD mongoimport --uri mongodb://mongodb:27017/lampadaire --collection Capteur --drop --jsonArray --file /Lampe.Capteur.json&& \
    mongoimport --uri mongodb://mongodb:27017/lampadaire --collection Horaire --drop --jsonArray --file /Lampe.Horaire.json && \
    mongoimport --uri mongodb://mongodb:27017/lampadaire --collection Lampadaire --drop --jsonArray --file /Lampe.Lampadaire.json && \
    mongoimport --uri mongodb://mongodb:27017/lampadaire --collection Utilisateur --drop --jsonArray --file /Lampe.Utilisateur.json