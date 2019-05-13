from app import app, db
from models import Admin, Production
from faker import Faker
import click




@app.cli.command()
@click.option("--u", default="admin")
@click.option("--p", default="pass")
@click.option("--m", default=100)
def forge(u,p,m):
    db.drop_all()
    db.create_all()

    fake = Faker(locale="zh_CN")

    admin = Admin(
        username=u,
        password=p
    )
    db.session.add(admin)
    db.session.commit()

    for i in range(m):
        production = Production(
            name=fake.name(),
            info=fake.sentence()
        )

        db.session.add(production)

    db.session.commit()
    click.echo("Done...")

