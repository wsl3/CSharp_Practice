from app import db
from datetime import datetime


class Admin(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(128), nullable=False, default="admin")
    password = db.Column(db.String(450), nullable=False, default="pass")

    def __repr__(self):
        return f"Admin<username: {self.username}>"

class Production(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(1000), nullable=False, index=True)
    info = db.Column(db.TEXT)
    timestamp = db.Column(db.DateTime, default=datetime.utcnow())


    def __repr__(self):
        return f"Production< id: {self.id} name: {self.name}>"
