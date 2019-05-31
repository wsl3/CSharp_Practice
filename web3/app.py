from flask import Flask, render_template, request, flash, redirect, url_for, session, jsonify
from flask_migrate import Migrate
from flask_sqlalchemy import SQLAlchemy
from functools import wraps
import config

app = Flask(__name__)
app.config.from_object(config)
db = SQLAlchemy(app)
migrate = Migrate(app, db)


def login_required(func):
    @wraps(func)
    def wrapper(*args, **kwargs):
        if session.get("username", None):
            # note!!! func()必须return
            return func(*args, **kwargs)
        else:
            return redirect(url_for("index"))

    return wrapper


@app.route("/")
def index():
    return render_template("index.html")


@app.route("/login/", methods=["GET", "POST"])
def login():
    if request.method == "POST":
        admin = Admin.query.get(1)
        if request.form.get('username') == admin.username and request.form.get('password') == admin.password:
            session["username"] = request.form.get("username")
            return redirect(url_for("admin"))

        return render_template("login.html")

    return render_template("login.html")


@app.route("/admin/<int:page>", methods=["GET", "POST"])
@app.route("/admin/", methods=["GET", "POST"])
@login_required
def admin(page=1):
    productions = Production.query.order_by(Production.timestamp.desc()).paginate(page, 25, False).items
    if request.method == "POST":
        res = {}
        res["status"] = "success"
        res["comment"] = []
        for msg in productions:
            temp = {
                "id": msg.id,
                "name": msg.name,
                "info": msg.info,
                "timestamp": msg.timestamp
            }
            res["comment"].append(temp)
        return jsonify(res)

    return render_template("production_show.html", productions=productions)


@app.route("/del/<int:id>")
@app.route("/del/")
@login_required
def delProduction(id=1):
    p = Production.query.get(id)
    if p:
        db.session.delete(p)
        db.session.commit()
    return redirect(url_for("admin"))


@app.route("/add/", methods=["GET", "POST"])
@login_required
def addProduction():
    if request.method == "POST":
        name = request.form.get("name", "不知名")
        info = request.form.get("info", "Nothing")

        p = Production(name=name, info=info)
        db.session.add(p)
        db.session.commit()
        return redirect(url_for("admin"))
    return render_template("production_add.html")


@app.route("/logout/")
def logout():
    if session.get("username", None):
        del session["username"]
    return redirect(url_for("index"))


from models import Admin, Production
from commands import forge
